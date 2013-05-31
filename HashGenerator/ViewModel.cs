using System.ComponentModel;
using System.Runtime.CompilerServices;

using HashGenerator.Annotations;

using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;

namespace HashGenerator
{
    public sealed class ViewModel : INotifyPropertyChanged
    {
        private string text;
        private string hash;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
                Hash = ComputeHash(text, "MD5");
                OnPropertyChanged();
            }
        }

        public string Hash
        {
            get
            {
                return hash;
            }

            set
            {
                hash = value;
                OnPropertyChanged();
            }
        }

        private static string ComputeHash(string str, string hashType)
        {
            var alg = HashAlgorithmProvider.OpenAlgorithm(hashType);
            IBuffer buff = CryptographicBuffer.ConvertStringToBinary(str, BinaryStringEncoding.Utf8);
            var hashed = alg.HashData(buff);
            var res = CryptographicBuffer.EncodeToHexString(hashed);
            return res;
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
