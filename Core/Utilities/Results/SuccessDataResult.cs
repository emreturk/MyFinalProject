using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data,
            string message):base(data,true, message)
        {
        }

        public SuccessDataResult(T data):base(data,true)
        {
                                
        }

        //başka bir versiyon
        public SuccessDataResult(string message):base(default,true,message)
        {
            
        }
        
        //bir diğer versiyon
        public SuccessDataResult():base(default,true)
        {
            
        }
    }

}
