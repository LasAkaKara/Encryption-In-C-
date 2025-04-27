# COMP1551: Message Encryption & Decryption

## Description
COMP1551 is a Windows Forms application designed to **encrypt** and **decrypt messages** using two different encryption methods:
- **Caesar Cipher**
- **AES Encryption**

This application allows users to input a string and either an integer (for Caesar cipher) or an AES key, and perform encryption or decryption operations on the input text. It supports:
- Encrypting and decrypting messages using the Caesar cipher technique.
- AES encryption and decryption using a passphrase-derived key.

## Features
- **Caesar Cipher** encryption/decryption with user-defined shift values.
- **AES encryption** with PBKDF2 key derivation for security.
- Supports AES encryption with an **AES key** and a **ciphertext** for decryption.
- Validation for input integrity (ensuring the string contains only alphabetic characters and the correct lengths).

## Prerequisites
- Visual Studio 2019 or later
- .NET Framework 4.7.2 or higher

## Installation
1. Clone the repository to your local machine.
   ```bash
   git clone https://github.com/your-username/COMP1551.git

2. Open the project in Visual Studio using the COMP1551.sln solution file.

3. Build and run the project from within Visual Studio.
## How to Use

### Caesar Cipher:
1. Enter a string containing only uppercase letters (A-Z).
2. Enter a shift number (an integer between -25 and 25).
3. Click **Encrypt** or **Decrypt** to perform the respective operation.

### AES Encryption:
1. Enter a string containing only uppercase letters (A-Z).
2. Enter a key for AES encryption.
3. Click **Encrypt** to perform AES encryption.

### AES Decryption with Key:
1. Enter the encrypted message in the **Encrypted Message** field.
2. Enter the key used for AES encryption in the **Encryption Key** field.
3. Click **Decrypt** to perform AES decryption.

## Code Structure
- **Form1.cs**: Contains the main form logic and handles user interactions, including encryption and decryption actions.
- **StringProcessing.cs**: Contains methods for Caesar cipher and AES encryption/decryption logic, input validation, and string manipulations.
- **COMP1551.csproj**: The project file used by Visual Studio to build and manage the application.
- **COMP1551.sln**: The solution file that contains references to all project files.
- **Program.cs**: The main entry point for the application, which now includes testing for both Caesar cipher and AES encryption.

## Testing
The application includes built-in encryption tests that run when the program starts:

- **Caesar Cipher Test**: Tests basic encryption and decryption using a shift value of 3.
- **AES Encryption Test**: Tests basic encryption and decryption using a test key ("TestKey123").

The results of these tests are displayed in a message box when the application is launched. The tests confirm that the encryption and decryption processes work as expected.

## Screenshots
(Optional: You can include screenshots here of the application’s UI or outputs.)

## License
This project is not licensed. All rights are reserved.

## Contact
If you have any questions, feel free to contact me via:
- GitHub: [LasAkaKara](https://github.com/LasAkaKara)