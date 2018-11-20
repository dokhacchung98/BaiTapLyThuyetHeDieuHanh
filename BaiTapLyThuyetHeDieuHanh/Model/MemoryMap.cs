using System;
using System.IO;

namespace BaiTapLyThuyetHeDieuHanh.Model
{
    class MemoryMap
    {
        public string MemoryMapName { get; }
        public string MemoryMapFileDirectory { get; }
        public string MemoryMapFilePath { get; }
        public string MutexName { get; }

        public MemoryMap(string memoryMapName)
        {
            Validate(memoryMapName);
            MemoryMapName = memoryMapName;
            MutexName = $"{MemoryMapName}-Mutex";
            MemoryMapFileDirectory = "c:\\temp";
            MemoryMapFilePath = Path.Combine(
                MemoryMapFileDirectory, memoryMapName);
        }

        private static void Validate(string memoryMapName)
        {
            if (string.IsNullOrWhiteSpace(memoryMapName))
                throw new ArgumentNullException(nameof(memoryMapName));
            if (memoryMapName.IndexOfAny(Path.GetInvalidPathChars()) > 0)
                throw new ArgumentException(
                    $"{memoryMapName} contains invalid characters.");
        }
    }
}
