using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbrUnitTests
{
    /// <summary>
    /// Generate a list (count long) of arbitary data type T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface ITestDataGenerator<T>
    {
        List<T> Generate(int count);
    }
}
