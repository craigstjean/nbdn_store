using System;

namespace nothinbutdotnetstore.infrastructure
{
    public class MapperType
    {
        public MapperType(Type input, Type output)
        {
            Input = input;
            Output = output;
        }

        public Type Input { get; set; }
        public Type Output { get; set; }
    }
}