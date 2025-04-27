using System;
using System.Windows.Forms;

namespace COMP1551
{
    public partial class Form1 : Form
    {
        private StringProcessing stringProcessing;
        private bool validInput = false;

        public Form1()
        {
            InitializeComponent();
            stringProcessing = new StringProcessing();
        }

        /// <summary>
        /// Validates input and updates notification for Caesar cipher
        /// </summary>
        private void ValidateInputAndNotify()
        {
            string inputString = stringInput.Text;
            string inputN = numberInput.Text;

            if (string.IsNullOrEmpty(inputN) || string.IsNullOrEmpty(inputString))
            {
                notification.Text = "Please enter both string and number";
                validInput = false;
                return;
            }

            if (!int.TryParse(inputN, out int N))
            {
                notification.Text = "Please enter a valid integer";
                validInput = false;
                return;
            }

            stringProcessing.SetInput(inputString, N);
            int output = stringProcessing.ValidateInput();

            string notify = "";
            if (output == 7)
            {
                notify = "Valid input";
                validInput = true;
            }
            else
            {
                notify = "Invalid input";
                if ((output & 1) == 0)
                {
                    notify += ", String must contain only characters A-Z";
                }
                if ((output & 2) == 0)
                {
                    notify += ", String length must be in range [1; 40]";
                }
                if ((output & 4) == 0)
                {
                    notify += ", Number must be in range [-25; 25]";
                }
                validInput = false;
            }
            notification.Text = notify;
        }

        /// <summary>
        /// Validates input and updates notification for AES encryption
        /// </summary>
        private void ValidateAesInputAndNotify()
        {
            string inputString = stringInput.Text;
            string inputKey = aesKeyTextBox.Text;

            if (string.IsNullOrEmpty(inputKey) || string.IsNullOrEmpty(inputString))
            {
                notification.Text = "Please enter both string and key";
                validInput = false;
                return;
            }

            stringProcessing.SetAesInput(inputString, inputKey);
            int output = stringProcessing.ValidateAesInput();

            string notify = "";
            if (output == 3)
            {
                notify = "Valid input";
                validInput = true;
            }
            else
            {
                notify = "Invalid input";
                if ((output & 1) == 0)
                {
                    notify += ", String must contain only characters A-Z";
                }
                if ((output & 2) == 0)
                {
                    notify += ", String length must be in range [1; 40]";
                }
                validInput = false;
            }
            notification.Text = notify;
        }

        private void EncodeButton_Click(object sender, EventArgs e)
        {
            ValidateInputAndNotify();
            if (!validInput) return;

            try
            {
                string result = stringProcessing.EncryptCaesar();
                EncodeResult.Text = result;
            }
            catch (Exception ex)
            {
                notification.Text = "Encryption failed: " + ex.Message;
            }
        }

        private void AdvancedEncryptButton_Click(object sender, EventArgs e)
        {
            ValidateAesInputAndNotify();
            if (!validInput) return;

            try
            {
                string result = stringProcessing.EncryptAES();
                EncodeResult.Text = result;
            }
            catch (Exception ex)
            {
                notification.Text = "Advanced encryption failed: " + ex.Message;
            }
        }

        private void ShowKeyButton_Click(object sender, EventArgs e)
        {
            if (stringProcessing.LastEncryptionMethod == EncryptionMethod.AES)
            {
                EncodeResult.Text = stringProcessing.LastAesKey;
            }
            else
            {
                notification.Text = "No AES encryption has been performed yet";
            }
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            if (stringProcessing.LastEncryptionMethod == EncryptionMethod.AES)
            {
                ValidateAesInputAndNotify();
            }
            else
            {
                ValidateInputAndNotify();
            }

            if (!validInput) return;

            try
            {
                string result = stringProcessing.Decrypt();
                if (result != null)
                {
                    EncodeResult.Text = result;
                }
                else
                {
                    notification.Text = "Decryption failed: Invalid encrypted text";
                }
            }
            catch (Exception ex)
            {
                notification.Text = "Decryption failed: " + ex.Message;
            }
        }

        private void DecryptWithKeyButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(aesKeyTextBox.Text))
            {
                notification.Text = "Please enter an AES key";
                return;
            }

            if (string.IsNullOrEmpty(encryptedMessageTextBox.Text))
            {
                notification.Text = "Please enter encrypted message";
                return;
            }

            try
            {
                string result = stringProcessing.DecryptWithKey(encryptedMessageTextBox.Text, aesKeyTextBox.Text);
                if (result != null)
                {
                    EncodeResult.Text = result;
                }
                else
                {
                    notification.Text = "Decryption failed: Invalid key or encrypted text";
                }
            }
            catch (Exception ex)
            {
                notification.Text = "Decryption failed: " + ex.Message;
            }
        }

        private void print1Button_Click(object sender, EventArgs e)
        {
            if (stringProcessing.LastEncryptionMethod == EncryptionMethod.AES)
            {
                ValidateAesInputAndNotify();
            }
            else
            {
                ValidateInputAndNotify();
            }

            if (!validInput) return;

            try
            {
                int[] arr = stringProcessing.GetAsciiValuesBeforeEncoding();
                EncodeResult.Text = string.Join("; ", arr);
            }
            catch (Exception ex)
            {
                notification.Text = "Failed to get ASCII values: " + ex.Message;
            }
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            if (stringProcessing.LastEncryptionMethod == EncryptionMethod.AES)
            {
                ValidateAesInputAndNotify();
            }
            else
            {
                ValidateInputAndNotify();
            }

            if (!validInput) return;

            try
            {
                string sortedString = stringProcessing.SortString();
                EncodeResult.Text = sortedString;
            }
            catch (Exception ex)
            {
                notification.Text = "Sorting failed: " + ex.Message;
            }
        }

        private void print2Button_Click(object sender, EventArgs e)
        {
            if (stringProcessing.LastEncryptionMethod == EncryptionMethod.AES)
            {
                ValidateAesInputAndNotify();
            }
            else
            {
                ValidateInputAndNotify();
            }

            if (!validInput) return;

            try
            {
                int[] arr = stringProcessing.GetAsciiValuesAfterEncoding();
                EncodeResult.Text = string.Join("; ", arr);
            }
            catch (Exception ex)
            {
                notification.Text = "Failed to get ASCII values: " + ex.Message;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            validInput = true;
        }
    }
}
