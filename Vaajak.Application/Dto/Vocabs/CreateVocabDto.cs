﻿namespace Vaajak.Application.Dto.Vocabs
{
    public class CreateVocabDto
    {
        public string Vocabulary { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Voice { get; set; } = string.Empty;
        public List<string> Translations { get; set; } = [];
        public Guid PackageId { get; set; }

    }
}
