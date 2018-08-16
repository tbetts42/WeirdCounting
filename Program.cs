using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace WeirdCounting
{
  class Program
  {
    const int HeaderOffset = 1;

    static void Main(string[] args)
    {
      // This program was to test a bug we encountered with how
      // row numbers were being added to each line read from a CSV file.
      // Every time the list was accessed, the numbers would jump.
      RunTest("Using int++ index", GetFileRows());
      RunTest("Using int++ index with .ToList()", GetFileRowsToList());
      RunTest("Using Linq Index", GetFileRowsWithLinqIndex());
    }

    static void RunTest(string method, IEnumerable<RowWithNumber> allRows)
    {
      Console.WriteLine(method);
      Console.WriteLine("First Pass");
      foreach (var row in allRows)
      {
        Console.WriteLine($"{row.RowNum}\t{row.Data}");
      }

      Console.WriteLine();
      Console.WriteLine("Second Pass");

      foreach (var row in allRows)
      {
        Console.WriteLine($"{row.RowNum}\t{row.Data}");
      }
      Console.WriteLine();

    }

    static IEnumerable<RowWithNumber> GetFileRows()
    {
      FileInfo sourceFile = GetSourceFile();
      int rowNum = HeaderOffset;
      var allRows = (from row in sourceFile.ReadAllLines()
                      .Skip(HeaderOffset)
                     select new RowWithNumber()
                     {
                       RowNum = rowNum++,
                       Data = row
                     });
      return allRows;
    }

    static IEnumerable<RowWithNumber> GetFileRowsToList()
    {
      FileInfo sourceFile = GetSourceFile();
      int rowNum = HeaderOffset;
      var allRows = from row in sourceFile.ReadAllLines()
                    .Skip(HeaderOffset)
                    select new RowWithNumber()
                    {
                      RowNum = rowNum++,
                      Data = row
                    };

      return allRows.ToList();
    }

    static IEnumerable<RowWithNumber> GetFileRowsWithLinqIndex()
    {
      FileInfo sourceFile = GetSourceFile();
      var allRows = sourceFile.ReadAllLines()
        .Skip(HeaderOffset)
        .Select((item, index) =>
          {
            return new RowWithNumber()
            {
              RowNum = index + HeaderOffset,
              Data = item
            };
          }
      );

      return allRows;
    }
    static FileInfo GetSourceFile()
    {
      const string filename = "testfile.txt";
      var fileInfo = new FileInfo(filename);

      return fileInfo;
    }

  }
}
