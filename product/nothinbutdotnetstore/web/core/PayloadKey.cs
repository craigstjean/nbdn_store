using System;
using System.Collections.Specialized;

namespace nothinbutdotnetstore.web.core
{
    public class PayloadKey<KeyValue>
    {
        readonly string key_name;

        public PayloadKey(string key_name)
        {
            this.key_name = key_name;
        }

        public static implicit operator string(PayloadKey<KeyValue> key)
        {
            return key.ToString();
        }

        public override string ToString()
        {
            return key_name;
        }

        public KeyValue map_from(NameValueCollection collection)
        {
        	var value = collection[key_name];

			if (value == null)
			{
				return default(KeyValue);
			}

        	return (KeyValue) Convert.ChangeType(value, typeof (KeyValue));
        }
    }
}