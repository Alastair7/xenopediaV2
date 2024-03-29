﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenopedia.Entities.Entity.Text;

namespace Xenopedia.Infrastructure.Text
{
    public interface ITextRepository
    {
        Task<bool> InsertText(TextEntity text);
        Task<bool> DeleteText(long idText);

        Task<bool> TextExistsById(long idText);

        Task<TextEntity> GetTextById(long idText);

        Task<IEnumerable<TextEntity>> GetAllText();
    }
}
