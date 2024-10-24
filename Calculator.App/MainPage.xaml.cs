namespace Calculator.App
{

    public partial class MainPage : ContentPage
    {

        private string _currentEntry = "";
        private string _operator = "";
        private double _firstNumber;
        private bool _isSecondNumber;
        public MainPage()
        {
            InitializeComponent();
        }

        
        private void OnNumberClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                _currentEntry += button.Text;
                ResultDisplay.Text = _currentEntry;
            }
        }

        
        private void OnOperatorClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null && !string.IsNullOrEmpty(_currentEntry))
            {
                _firstNumber = double.Parse(_currentEntry);
                _operator = button.Text;
                _currentEntry = "";
                _isSecondNumber = true;
            }
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            if (_isSecondNumber && !string.IsNullOrEmpty(_currentEntry))
            {
                double secondNumber = double.Parse(_currentEntry);
                double result = 0;

                switch (_operator)
                {
                    case "+":
                        result = _firstNumber + secondNumber;
                        break;
                    case "-":
                        result = _firstNumber - secondNumber;
                        break;
                    case "×":
                        result = _firstNumber * secondNumber;
                        break;
                    case "÷":
                        if (secondNumber != 0)
                            result = _firstNumber / secondNumber;
                        else
                        {
                            DisplayAlert("Hata", "Bölen 0 olamaz!", "Tamam");
                            return;
                        }
                        break;
                }

                ResultDisplay.Text = result.ToString();
                _currentEntry = result.ToString();
                _isSecondNumber = false;
            }
        }

        
        private void OnClearClicked(object sender, EventArgs e)
        {
            _currentEntry = "";
            _firstNumber = 0;
            _operator = "";
            _isSecondNumber = false;
            ResultDisplay.Text = "0";
        }
    }
}
