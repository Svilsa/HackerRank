namespace TextEncryption;

public abstract class StringEncryptorBase
{
    public abstract string Encrypt(string plainText, string passPhrase);

    public abstract string Decrypt(string cipherText, string passPhrase);
}