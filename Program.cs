using System;
using System.Text;
using System.Windows.Forms;

namespace COMP1551
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Run tests
            RunEncryptionTests();

            // Launch the application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void RunEncryptionTests()
        {
            StringBuilder testResults = new StringBuilder();
            testResults.AppendLine("=== Encryption Tests ===");
            testResults.AppendLine();

            // Test Caesar Cipher
            TestCaesarCipher(testResults);

            // Test AES Encryption
            TestAesEncryption(testResults);

            // Display results in a message box
            MessageBox.Show(testResults.ToString(), "Encryption Test Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void TestCaesarCipher(StringBuilder results)
        {
            results.AppendLine("=== Caesar Cipher Test ===");
            var processor = new StringProcessing();

            // Test Case: Basic encryption and decryption
            string originalText = "HELLO";
            int shift = 3;
            results.AppendLine($"\nOriginal text: {originalText}");
            results.AppendLine($"Shift value: {shift}");

            // Encrypt
            processor.SetInput(originalText, shift);
            string encrypted = processor.EncryptCaesar();
            results.AppendLine($"Encrypted: {encrypted}");

            // Decrypt with negative shift
            processor.SetInput(encrypted, -shift);
            string decrypted = processor.EncryptCaesar();
            results.AppendLine($"Decrypted: {decrypted}");
            results.AppendLine($"Test passed: {decrypted == originalText}");
        }

        private static void TestAesEncryption(StringBuilder results)
        {
            results.AppendLine("\n=== AES Encryption Test ===");
            var processor = new StringProcessing();

            // Test Case: Basic encryption and decryption
            string originalText = "HELLO";
            string key = "TestKey123";
            results.AppendLine($"\nOriginal text: {originalText}");
            results.AppendLine($"Key: {key}");

            // Encrypt
            processor.SetAesInput(originalText, key);
            string encrypted = processor.EncryptAES();
            results.AppendLine($"Encrypted: {encrypted}");

            // Decrypt
            string decrypted = processor.DecryptWithKey(encrypted, key);
            results.AppendLine($"Decrypted: {decrypted}");
            results.AppendLine($"Test passed: {decrypted == originalText}");
        }
    }
}
