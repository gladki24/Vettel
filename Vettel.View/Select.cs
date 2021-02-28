using System;
using System.Collections.Generic;
using System.Text;

namespace Vettel.View
{
    internal class Select<TValue> : ISelect<TValue>
    {
        private readonly IList<KeyValuePair<string, TValue>> _options;
        private readonly IPrinter _printer;
        private readonly IReader _reader;
        private int _selectedLine = 1;

        public Select(IList<KeyValuePair<string, TValue>> options)
        {
            _options = options;
            _printer = new Printer();
            _reader = new Reader();
        }

        public TValue Print()
        {
            _printer.Print(GetFormattedOptions());
            ConsoleKeyInfo key;

            do
            {
                key = _reader.ReadKeyInfo();
                _printer.Clear();

                if (key.Key == ConsoleKey.UpArrow)
                    PreviousOption();

                if (key.Key == ConsoleKey.DownArrow)
                    NextOption();

                _printer.Print(GetFormattedOptions());

            } while (key.Key != ConsoleKey.Enter);

            return _options[_selectedLine - 1].Value;
        }

        private void NextOption()
        {
            if (IsSelectedLast())
                _selectedLine = 1;
            else
                _selectedLine++;
        }

        private void PreviousOption()
        {
            if (IsSelectedFirst())
                _selectedLine = _options.Count;
            else
                _selectedLine--;
        }

        private bool IsSelectedLast()
        {
            return _options.Count == _selectedLine;
        }

        private bool IsSelectedFirst()
        {
            return _selectedLine == 1;
        }

        private string GetFormattedOptions()
        {
            int lineNumber = 1;
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var option in _options)
            {
                stringBuilder.Append("[");

                if (lineNumber == _selectedLine)
                {
                    stringBuilder.Append("x");
                }
                else
                {
                    stringBuilder.Append(" ");
                }


                stringBuilder.Append("] ");
                stringBuilder.Append(lineNumber);
                stringBuilder.Append(". ");
                stringBuilder.Append(option.Key);
                stringBuilder.AppendLine();

                lineNumber++;
            }

            return stringBuilder.ToString();
        }
    }
}
