using System.Security.Cryptography;

namespace DictionaryImplementation
{
    public class MyDictionary
    {
        #region Private Properties

        private LinkedList<(int, int)>[] _buckets = new LinkedList<(int, int)>[16];

        #endregion

        #region Public Methods

        public void Put(int key, int value)
        {
            int bucketIndex = getMD5Hash(key) % _buckets.Length;

            Console.WriteLine($"Key: {key}, Value: {value}, Bucket Index: {bucketIndex}");

            if (_buckets[bucketIndex] == null)
            {
                _buckets[bucketIndex] = new LinkedList<(int, int)>();
                _buckets[bucketIndex].AddFirst((key, value));
                return;
            }

            var bucket = _buckets[bucketIndex];

            foreach (var item in bucket)
            {
                if (item.Item1 == key)
                {
                    bucket.Remove(item);
                    break;
                }
            }

            bucket.AddFirst((key, value));
        }

        public int Get(int key)
        {
            int bucketIndex = getMD5Hash(key) % _buckets.Length;

            if (_buckets[bucketIndex] != null)
            {
                var bucket = _buckets[bucketIndex];
                foreach (var item in bucket)
                {
                    if (item.Item1 == key)
                    {
                        return item.Item2;
                    }
                }
            }

            throw new KeyNotFoundException($"Key {key} not found");
        }

        #endregion

        #region Private Methods

        private int getMD5Hash(int key)
        {
            byte[] inputBytes = BitConverter.GetBytes(key);

            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                uint unsignedHash = BitConverter.ToUInt32(hashBytes, 0);
                return (int)(unsignedHash & 0x7FFFFFFF);
            }
        }

        #endregion
    }
}
