using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Cryptography
{

    //Symmetric Encryption 

    internal class Program
    {
        //Hashing Example
        static string ComputeHash(string input)
        {
            //SHA is Secutred Hash Algorithm.
            // Create an instance of the SHA-256 algorithm
            using ( SHA256 sha256 = SHA256.Create() )
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));


                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-" , "").ToLower();
            }
        }

        #region SymmetricEncryption

        public static void SymmetricEncryption()

        {
            // Original data
            string originalData = "Sensitive information";


            // Key for AES encryption (128-bit key)
            string key = "1234567890123456";


            // Encrypt the original data
            string encryptedData = Encrypt(originalData , key);


            // Decrypt the encrypted data
            string decryptedData = Decrypt(encryptedData , key);


            // Display results
            Console.WriteLine($"Original Data: {originalData}");
            Console.WriteLine($"Encrypted Data: {encryptedData}");
            Console.WriteLine($"Decrypted Data: {decryptedData}");
        }
        static string Encrypt(string plainText , string key)
        {
            using ( Aes aesAlg = Aes.Create() )
            {
                // Set the key and IV for AES encryption
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create an encryptor
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key , aesAlg.IV);


                // Encrypt the data
                using ( var msEncrypt = new System.IO.MemoryStream() )
                {
                    using ( var csEncrypt = new CryptoStream(msEncrypt , encryptor , CryptoStreamMode.Write) )
                    using ( var swEncrypt = new System.IO.StreamWriter(csEncrypt) )
                    {
                        swEncrypt.Write(plainText);
                    }


                    // Return the encrypted data as a Base64-encoded string
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }


        static string Decrypt(string cipherText , string key)
        {
            using ( Aes aesAlg = Aes.Create() )
            {
                // Set the key and IV for AES decryption
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create a decryptor
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key , aesAlg.IV);


                // Decrypt the data
                using ( var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)) )
                using ( var csDecrypt = new CryptoStream(msDecrypt , decryptor , CryptoStreamMode.Read) )
                using ( var srDecrypt = new System.IO.StreamReader(csDecrypt) )
                {
                    // Read the decrypted data from the StreamReader
                    return srDecrypt.ReadToEnd();
                }
            }
        }

        #endregion

   
        #region ASymmetricEncryption
        public static void ASymmetricEncryption()
        {
            try
            {
                // Generate public and private key pair
                using ( RSACryptoServiceProvider rsa = new RSACryptoServiceProvider() )
                {
                    // Get the public key
                    /*
                     When exporting the public key, ToXmlString(false) is used with the argument set 
                     to false to indicate that only the public parameters should be included in the XML string.
                     */
                    string publicKey = rsa.ToXmlString(false);


                    // Get the private key
                    string privateKey = rsa.ToXmlString(true);


                    // Original message
                    string originalMessage = "Hello, this is a secret message!";


                    // Encrypt using the public key
                    string encryptedMessage = AsEncrypt(originalMessage , publicKey);


                    // Decrypt using the private key
                    string decryptedMessage = AsDecrypt(encryptedMessage , privateKey);


                    // Display the results
                    Console.WriteLine($"\n\nPublic Key:\n {publicKey}");
                    Console.WriteLine($"\n\nPrivate Key:\n {privateKey}");
                    Console.WriteLine($"\nOriginal Message:\n {originalMessage}");
                    Console.WriteLine($"\nEncrypted Message:\n {encryptedMessage}");
                    Console.WriteLine($"\nDecrypted Message:\n {decryptedMessage}");


                    // Wait for user input before closing the console window
                    Console.WriteLine("\nPress any key to exit...");
                    Console.ReadKey();
                }
            }
            catch ( CryptographicException ex )
            {
                Console.WriteLine($"Encryption/Decryption error: {ex.Message}");
                Console.ReadKey();
            }
            catch ( Exception ex )
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                Console.ReadKey();
            }
        }


        static string AsEncrypt(string plainText , string publicKey)
        {
            try
            {
                using ( RSACryptoServiceProvider rsa = new RSACryptoServiceProvider() )
                {
                    rsa.FromXmlString(publicKey);


                    byte[] encryptedData = rsa.Encrypt(Encoding.UTF8.GetBytes(plainText) , false);
                    return Convert.ToBase64String(encryptedData);
                }
            }
            catch ( CryptographicException ex )
            {
                Console.WriteLine($"Encryption error: {ex.Message}");
                throw; // Rethrow the exception to be caught in the Main method
            }
        }


        public static string AsDecrypt(string cipherText , string privateKey)
        {
            try
            {
                using ( RSACryptoServiceProvider rsa = new RSACryptoServiceProvider() )
                {
                    rsa.FromXmlString(privateKey);


                    byte[] encryptedData = Convert.FromBase64String(cipherText);
                    byte[] decryptedData = rsa.Decrypt(encryptedData , false);


                    return Encoding.UTF8.GetString(decryptedData);
                }
            }
            catch ( CryptographicException ex )
            {
                Console.WriteLine($"Decryption error: {ex.Message}");
                throw; // Rethrow the exception to be caught in the Main method
            }
        }
        #endregion

        #region Encrypt and Decrypt Image

        public static void EncryptandDecryptImage()
        {

            string inputFile = "c:\\Image\\MyImage.jpg";
            string encryptedFile = "c:\\Image\\encrypted.jpg";
            string decryptedFile = "c:\\Image\\decrypted.jpg";


            // Generate a random IV for each encryption operation
            byte[] iv;
            using ( Aes aesAlg = Aes.Create() )
            {
                iv = aesAlg.IV;
            }


            string key = "1234567890123456";


            EncryptFile(inputFile , encryptedFile , key , iv);
            DecryptFile(encryptedFile , decryptedFile , key , iv);


            Console.WriteLine("Encryption and decryption completed successfully.");
            Console.WriteLine("go to c:\\Image folder to see the results");
            Console.ReadKey();

        }

        static void EncryptFile(string inputFile , string outputFile , string key , byte[] iv)
        {
            using ( Aes aesAlg = Aes.Create() )
            {
                aesAlg.Key = System.Text.Encoding.UTF8.GetBytes(key);
                aesAlg.IV = iv;


                using ( FileStream fsInput = new FileStream(inputFile , FileMode.Open) )
                using ( FileStream fsOutput = new FileStream(outputFile , FileMode.Create) )
                using ( ICryptoTransform encryptor = aesAlg.CreateEncryptor() )
                using ( CryptoStream cryptoStream = new CryptoStream(fsOutput , encryptor , CryptoStreamMode.Write) )
                {
                    // Write the IV to the beginning of the file
                    fsOutput.Write(iv , 0 , iv.Length);
                    fsInput.CopyTo(cryptoStream);
                }
            }
        }


        static void DecryptFile(string inputFile , string outputFile , string key , byte[] iv)
        {
            using ( Aes aesAlg = Aes.Create() )
            {
                aesAlg.Key = System.Text.Encoding.UTF8.GetBytes(key);
                aesAlg.IV = iv;


                using ( FileStream fsInput = new FileStream(inputFile , FileMode.Open) )
                using ( FileStream fsOutput = new FileStream(outputFile , FileMode.Create) )
                using ( ICryptoTransform decryptor = aesAlg.CreateDecryptor() )
                using ( CryptoStream cryptoStream = new CryptoStream(fsOutput , decryptor , CryptoStreamMode.Write) )
                {
                    // Skip the IV at the beginning of the file
                    fsInput.Seek(iv.Length , SeekOrigin.Begin);
                    fsInput.CopyTo(cryptoStream);
                }
            }
        }
    
        #endregion

        static void Main(string[] args)
        {

            // Input data
            string data = "Mohammed Abu-Hadhoud";


            // Compute the SHA-256 hash of the input data
            string hashedData = ComputeHash(data);


            // Display the original data and its hash
            Console.WriteLine($"Original Data: {data}");
            Console.WriteLine($"Hashed Data: {hashedData}");

            SymmetricEncryption();
            // Pause to keep the console window open for viewing the results
            Console.ReadKey();
            ASymmetricEncryption();
            Console.ReadKey();
        }
    }
}
