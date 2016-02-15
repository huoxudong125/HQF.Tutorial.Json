using System;
using System.Linq;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;

namespace HQF.Tutorial.JsonFormater.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        public ViewAViewModel()
        {
            // This command will be executed when the selection of the ListBox in the view changes.
            this.FormatJsonCommand = new DelegateCommand(OnItemSelected
                ,()=>!string.IsNullOrEmpty(OrignJson));
        }

        public ICommand FormatJsonCommand { get; private set; }

        private string _orignJson = "{ \"Data\":\"Hello World\" }";
        private string _formatedJson;

        public string OrignJson
        {
            get { return _orignJson; }
            set { SetProperty(ref _orignJson, value); }
        }

        public string FormatedJson
        {
            get { return _formatedJson; }
            set { SetProperty(ref _formatedJson, value); }
        }

        private void OnItemSelected()
        {
            FormatedJson=JsonHelper.FormatJson(OrignJson);
        }
    }

    public class JsonHelper
    {
        private const string INDENT_STRING = "    ";

        public static string FormatJson(string json)
        {
            int indentation = 0;
            int quoteCount = 0;
            var result =
                from ch in json
                let quotes = ch == '"' ? quoteCount++ : quoteCount
                let lineBreak = ch == ',' && quotes % 2 == 0 ? ch + Environment.NewLine + String.Concat(Enumerable.Repeat(INDENT_STRING, indentation)) : null
                let openChar = ch == '{' || ch == '[' ? ch + Environment.NewLine + String.Concat(Enumerable.Repeat(INDENT_STRING, ++indentation)) : ch.ToString()
                let closeChar = ch == '}' || ch == ']' ? Environment.NewLine + String.Concat(Enumerable.Repeat(INDENT_STRING, --indentation)) + ch : ch.ToString()
                select lineBreak == null
                            ? openChar.Length > 1
                                ? openChar
                                : closeChar
                            : lineBreak;

            return String.Concat(result);
        }
    }
}