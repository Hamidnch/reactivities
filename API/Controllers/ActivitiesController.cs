using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseController
    {
        private readonly DataContext _context;
        public ActivitiesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            if(_context is null || _context.Activities is null) return NotFound();
            return await _context.Activities.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await _context.Activities.FindAsync(id);
        }
    }
}

//پس از اضافه کردن فایل‌ها به محیط استیج، هر تغییری که در فایل‌ها اعمال شود، این تغییرات، توسط گیت، دنبال خواهد شد.
//وقتی که تغییرات لازم در فایل‌(ها) انجام پذیرفت، با اجرای کامیت، تغییرات، ذخیره شده و به عنوان یک وضعیت یا ورژن جدید،در تاریخچه‌ی پروژه‌ی ما ثبت می‌گردد.
//git config --global user.email "YOUR_EMAIL_ADDRESS"
//git config --global user.name "YOUR NAME"
//git config --list
//git init
//git add Readme.md
//dotnet new -l
//dotnet new gitignore
//git add .
//git add -A -- تمام فایل‌های موجود در دایرکتوری جاری را در مرحله‌ی استیج قرار می‌دهد. 
//git status  -- با اجرای این دستور می‌توانیم از وضعیت فایل‌های موجود در استیج ، گزارشی داشته باشیم.
//git commit -m "your message"
//git diff   -- برای مشاهده‌ی تغییرات صورت گرفته پس از ثبت آخرین تغییرات یا تغییرات کامیت نشده،
//git branch -m main
//git checkout branch1 -- برای سویچ کردن به شاخه‌ی مورد نظر
//git merge branch1 --در صورتی که بخواهیم شاخه‌ی ایجاد شده را با شاخه‌ی اصلی یکی نماییم
//git remote  -- برای ارتباط با سروری که مخزن پروژه بر روی آن قرار دارد
//git remote add origin https://github.com/Hamidnch/reactivities.git   -- برای اضافه کردن یک مخزن ریموت به گیت
//git push -u origin main   -- ارسال تغییرات به برنچ یا شاخه اصلی که در اینجا نام شاخه اصلی main هست.
//git push origin master -- برای ارسال تغییرات کامیت شده، در مخزن لوکال به مخزن ریموت
//git pull origin master  -- برای دریافت تغییرات اعمال شده در مخزن ریموت، و بروزرسانی مخزن محلی
//git reset HEAD file1  -- در صورتی که بخواهیم یک فایل را به آخرین وضعیت کامیت شده برگردانیم و تغییرات اعمال شده را نادیده بگیریم
//git log   -- برای اطلاع از مستندات و تاریخچه‌ی تغییرات انجام شده


//dotnet tool list
//dotnet tool list -g
//dotnet tool install -g dotnet-ef
//dotnet tool update -g dotnet-ef
//dotnet ef migrations add InitialCreate --context DataContext --project .\Persistence\ --startup-project ./API
//dotnet ef database update -p ./Persistence -s ./API