using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace COMP1551
{
    /// <summary>
    /// Defines the encryption methods available
    /// </summary>
    public enum EncryptionMethod
    {
        Caesar,
        AES
    }

    /// <summary>
    /// Handles string processing operations including encoding, encryption, and sorting
    /// </summary>
    public class StringProcessing
    {
        private string inputString;
        private int inputN;
        private string inputAesKey;
        private List<int> tempArray = new List<int>();
        private string encryptedText;
        private EncryptionMethod lastEncryptionMethod;
        private string lastAesKey;

        /// <summary>
        /// Gets or sets the input string
        /// </summary>
        public string InputString
        {
            get => inputString;
            set => inputString = value;
        }

        /// <summary>
        /// Gets or sets the input number for Caesar cipher
        /// </summary>
        public int InputN
        {
            get => inputN;
            set => inputN = value;
        }

        /// <summary>
        /// Gets or sets the input key for AES encryption
        /// </summary>
        public string InputAesKey
        {
            get => inputAesKey;
            set => inputAesKey = value;
        }

        /// <summary>
        /// Gets the last used encryption method
        /// </summary>
        public EncryptionMethod LastEncryptionMethod => lastEncryptionMethod;

        /// <summary>
        /// Gets the last used AES key
        /// </summary>
        public string LastAesKey => lastAesKey;

        /// <summary>
        /// Sets input values for Caesar cipher
        /// </summary>
        public void SetInput(string inputString, int inputN)
        {
            this.inputString = inputString;
            this.inputN = inputN;
        }

        /// <summary>
        /// Sets input values for AES encryption
        /// </summary>
        public void SetAesInput(string inputString, string inputAesKey)
        {
            this.inputString = inputString;
            this.inputAesKey = inputAesKey;
        }

        /// <summary>
        /// Validates the input string and number for Caesar cipher
        /// </summary>
        /// <returns>Bit flags indicating validation status</returns>
        public int ValidateInput()
        {
            int output = 7; // 111 in binary: assume all conditions valid

            // Bit 1: Validate string length [1; 40]
            output = output & ((inputString.Length >= 1 && inputString.Length <= 40) ? 7 : 5);

            // Bit 0: Validate all characters A-Z
            output = output & (inputString.All(c => c >= 'A' && c <= 'Z') ? 7 : 6);

            // Bit 2: Validate inputN in [-25; 25]
            output = output & ((inputN >= -25 && inputN <= 25) ? 7 : 3);

            return output;
        }

        /// <summary>
        /// Validates the input string for AES encryption
        /// </summary>
        /// <returns>Bit flags indicating validation status</returns>
        public int ValidateAesInput()
        {
            int output = 3; // 011 in binary: assume string conditions valid

            // Bit 1: Validate string length [1; 40]
            output = output & ((inputString.Length >= 1 && inputString.Length <= 40) ? 3 : 1);

            // Bit 0: Validate all characters A-Z
            output = output & (inputString.All(c => c >= 'A' && c <= 'Z') ? 3 : 2);

            return output;
        }

        /// <summary>
        /// Encrypts the input string using Caesar cipher
        /// </summary>
        public string EncryptCaesar()
        {
            lastEncryptionMethod = EncryptionMethod.Caesar;
            encryptedText = EncodeString();
            return encryptedText;
        }

        /// <summary>
        /// Encrypts the input string using AES with PBKDF2 key derivation
        /// </summary>
        public string EncryptAES()
        {
            try
            {
                lastEncryptionMethod = EncryptionMethod.AES;
                string plainText = inputString;
                string key = inputAesKey;
                lastAesKey = key;

                using (Aes aes = Aes.Create())
                {
                    // Generate a random IV
                    aes.GenerateIV();
                    byte[] iv = aes.IV;

                    // Use PBKDF2 for key derivation
                    using (var deriveBytes = new Rfc2898DeriveBytes(key, iv, 10000))
                    {
                        aes.Key = deriveBytes.GetBytes(32); // 256 bits
                    }

                    ICryptoTransform encryptor = aes.CreateEncryptor();

                    byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
                    byte[] encrypted = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

                    // Combine IV and encrypted data
                    byte[] result = new byte[iv.Length + encrypted.Length];
                    Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                    Buffer.BlockCopy(encrypted, 0, result, iv.Length, encrypted.Length);

                    encryptedText = Convert.ToBase64String(result);
                    return encryptedText;
                }
            }
            catch (Exception ex)
            {
                throw new CryptographicException("Encryption failed", ex);
            }
        }

        /// <summary>
        /// Decrypts the encrypted string based on the last used encryption method
        /// </summary>
        public string Decrypt()
        {
            if (string.IsNullOrEmpty(encryptedText))
                return null;

            switch (lastEncryptionMethod)
            {
                case EncryptionMethod.Caesar:
                    return DecryptCaesar();
                case EncryptionMethod.AES:
                    return DecryptAES();
                default:
                    throw new InvalidOperationException("No encryption method was used");
            }
        }

        /// <summary>
        /// Decrypts the encrypted string using a provided AES key
        /// </summary>
        public string DecryptWithKey(string encryptedText, string key)
        {
            try
            {
                byte[] fullCipher = Convert.FromBase64String(encryptedText);

                using (Aes aes = Aes.Create())
                {
                    // Extract IV from the beginning of the ciphertext
                    byte[] iv = new byte[16];
                    byte[] cipherText = new byte[fullCipher.Length - 16];
                    Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
                    Buffer.BlockCopy(fullCipher, iv.Length, cipherText, 0, cipherText.Length);

                    aes.IV = iv;

                    // Use PBKDF2 for key derivation
                    using (var deriveBytes = new Rfc2898DeriveBytes(key, iv, 10000))
                    {
                        aes.Key = deriveBytes.GetBytes(32);
                    }

                    ICryptoTransform decryptor = aes.CreateDecryptor();
                    byte[] decrypted = decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);

                    return Encoding.UTF8.GetString(decrypted);
                }
            }
            catch (Exception ex)
            {
                throw new CryptographicException("Decryption failed", ex);
            }
        }

        private string DecryptCaesar()
        {
            string result = "";
            foreach (char ch in encryptedText)
            {
                char newChar = (char)((((ch - 'A') - inputN) % 26 + 26) % 26 + 'A');
                result += newChar;
            }
            return result;
        }

        private string DecryptAES()
        {
            try
            {
                string key = inputAesKey;
                byte[] fullCipher = Convert.FromBase64String(encryptedText);

                using (Aes aes = Aes.Create())
                {
                    // Extract IV from the beginning of the ciphertext
                    byte[] iv = new byte[16];
                    byte[] cipherText = new byte[fullCipher.Length - 16];
                    Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
                    Buffer.BlockCopy(fullCipher, iv.Length, cipherText, 0, cipherText.Length);

                    aes.IV = iv;

                    // Use PBKDF2 for key derivation
                    using (var deriveBytes = new Rfc2898DeriveBytes(key, iv, 10000))
                    {
                        aes.Key = deriveBytes.GetBytes(32);
                    }

                    ICryptoTransform decryptor = aes.CreateDecryptor();
                    byte[] decrypted = decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);

                    return Encoding.UTF8.GetString(decrypted);
                }
            }
            catch (Exception ex)
            {
                throw new CryptographicException("Decryption failed", ex);
            }
        }

        /// <summary>
        /// Encodes the input string using the Caesar cipher
        /// </summary>
        public string EncodeString()
        {
            string result = "";
            foreach (char ch in inputString)
            {
                char newChar = (char)((((ch - 'A') + inputN) % 26 + 26) % 26 + 'A');
                result += newChar;
            }
            return result;
        }

        /// <summary>
        /// Gets ASCII values of characters in the input string
        /// </summary>
        public int[] GetAsciiValues(string input)
        {
            return input.Select(c => (int)c).ToArray();
        }

        /// <summary>
        /// Gets ASCII values before encoding
        /// </summary>
        public int[] GetAsciiValuesBeforeEncoding()
        {
            string decryptedText = Decrypt();
            return decryptedText != null ? GetAsciiValues(decryptedText) : GetAsciiValues(inputString);
        }

        /// <summary>
        /// Gets ASCII values after encoding
        /// </summary>
        public int[] GetAsciiValuesAfterEncoding()
        {
            return GetAsciiValues(encryptedText ?? EncodeString());
        }

        /// <summary>
        /// Sorts the input string alphabetically using QuickSort
        /// </summary>
        public string SortString()
        {
            char[] chars = inputString.ToCharArray();
            QuickSort(chars, 0, chars.Length - 1);
            return new string(chars);
        }

        private void QuickSort(char[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        private int Partition(char[] arr, int low, int high)
        {
            char pivot = arr[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    char temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            char temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }
    }
} 