using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace P129NLayerArchitectura.Service.DTOS.CategoryDTOs
{
    public class CategoryPostDto
    {
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public Nullable<int> ParentId { get; set; }
        public IFormFile File { get; set; }
    }

    public class CategoryPostDtoValidator : AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("Name Is Required")
                .MaximumLength(25).WithMessage("Name Must Be Maximum Length 25")
                .MinimumLength(5).WithMessage("Name Must Be Minimum Length 25");

            RuleFor(r => r).Custom((r, context) =>
            {
                if (r.IsMain)
                {
                    if (r.File == null)
                    {
                        context.AddFailure("File", "File Is Reuired");
                    }

                    if ((r.File.Length / 1024) >30)
                    {
                        context.AddFailure("File", "File Size Must Be Maximum 30kb");
                    }

                    if (r.File.ContentType != "image/jpeg")
                    {
                        context.AddFailure("File", "File Type Must Be .jpg or .jpeg");
                    }
                }
                else
                {
                    if (r.ParentId == null)
                    {
                        context.AddFailure("ParentId", "Parent Id Is Required");
                    }
                }
            });
        }
    }
}
