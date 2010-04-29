using System;

namespace nothinbutdotnetstore.infrastructure
{
    public class MissingMapper<Input, Output> : Mapper<Input, Output>
    {
        public Output map(Input input)
        {
            throw new NotImplementedException();
        }
    }
}