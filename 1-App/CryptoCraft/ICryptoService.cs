using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCraft;

public interface ICryptoService
{
    string Encrypt(string textToEncrypt);
    string Decrypt(string encryptedText);

}
