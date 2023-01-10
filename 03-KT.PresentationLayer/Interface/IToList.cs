using System.Collections.Generic;

namespace _03_KT.PresentationLayer.Interface
{
    public interface IToList<T> 
    {
        HashSet<T> List();
    }
}
