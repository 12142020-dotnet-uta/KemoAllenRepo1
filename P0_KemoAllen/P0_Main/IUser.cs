using System;

namespace P0_KemoAllen
{
    public interface IUser
    {
        Guid userId();
        
        string firstName();
       
        string lastName();
        
    }
}