using System;
using System.Collections.Generic;
using System.Text;

namespace LearningSystem.Services.Interfaces
{
    public interface IPdfGenerator
    {
        byte[] GeneratePdfFromHtml(string html);
    }
}
