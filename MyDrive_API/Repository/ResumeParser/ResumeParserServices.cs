using AutoMapper;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.EntityFrameworkCore;
using MyDrive_API.Classes;
using MyDrive_API.Data_Access;
using MyDrive_API.Models.FileFolder;
using Newtonsoft.Json;
using System.Text;
using thredds.catalog.dl;
using TikaOnDotNet.TextExtraction;

namespace MyDrive_API.Repository.ResumeParser
{
    public class ResumeParserServices : IResumeParserService
    {
        public readonly MyDriveDBContext _db;
        public readonly IMapper _mapper;

        public ResumeParserServices(MyDriveDBContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ApiResponse<FileStorageDetails>> GetFileById(string id)
        {
            ApiResponse<FileStorageDetails> apiResponse = new();

            if (!string.IsNullOrEmpty(id))
            {
                var file = await _db.FileStorageInfos.AsNoTracking().Where(fs => fs.Id == id).FirstOrDefaultAsync();
                if (file != null)
                {
                    List<FileStorageDetails> files = [file];
                    apiResponse.SetSuccessApiResopnse(files);
                }
            }

            return apiResponse;
        }

        public ApiResponse<string> GetTextFromFile(FileStorageDetails fileStorageDetails)
        {
            ApiResponse<string> apiResponse = new();

            if (fileStorageDetails.Data != null )
            {
                using PdfReader pdfReader = new(fileStorageDetails.Data);
                StringBuilder text = new();
                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();

                for(int pageNo = 1;pageNo<= pdfReader.NumberOfPages;pageNo++)
                {
                    string txt = PdfTextExtractor.GetTextFromPage(pdfReader, pageNo,strategy);
                    text.Append(txt);   
                }

                List<string> data = [text.ToString()];
                apiResponse.SetSuccessApiResopnse(data);
            }

            return apiResponse;
        }

    }
}


