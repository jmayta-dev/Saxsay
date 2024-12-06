using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW.SAXSAY.Core.Application.Contracts;

public interface IIdentifierGenerationService
{
    /// <summary>
    /// Generate the identifier with length provided
    /// </summary>
    /// <param name="numericLength">Numeric portion length</param>
    /// <param name="stringLength">String portion length</param>
    /// <returns>Unique identifier with numeric and character portions</returns>
    string Generate(int numericLength = 15, int stringLength = 6);
}
