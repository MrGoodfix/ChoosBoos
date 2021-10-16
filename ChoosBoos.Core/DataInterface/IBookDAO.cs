using ChoosBoos.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChoosBoos.Core.DataInterface
{
    public interface IBookDAO
    {
        Book Save(Book book);
    }
}
