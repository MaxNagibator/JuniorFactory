using Domiki.Web;
using Domiki.Web.Business.Core;
using Domiki.Web.Business.Models;
using Domiki.Web.Data;
using Domiki.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace Domiki.Controllers
{
    [ApiController]
    public class SystemController : ControllerBase
    {
        private readonly ILogger<DomikiController> _logger;
        private readonly DomikManager _domikManager;
        private readonly ResourceManager _resourceManager;
        private readonly ApplicationDbContext _context;

        public SystemController(ILogger<DomikiController> logger, DomikManager domikManager, ResourceManager resourceManager
            , ApplicationDbContext context)
        {
            _logger = logger;
            _domikManager = domikManager;
            _resourceManager = resourceManager;
            _context = context;
        }

        [HttpGet]
        [Route("/System/Test")]
        public string[] GetDomikTypes()
        {
            if (1 == 0)
            {
                // SELECT Name FROM dbo.DomikTypes
                return _context.DomikTypes.Select(x => x.Name).ToArray();
                // так бодрее работает, если не планируем менять записи.
                return _context.DomikTypes.Select(x => x.Name).AsNoTracking().ToArray();

                // SELECT * FROM dbo.DomikTypes
                return _context.DomikTypes.ToArray().Select(x => x.Name).ToArray();

                // SELECT Name FROM dbo.DomikType WHERE MaxCount = 2
                return _context.DomikTypes.Where(x => x.MaxCount == 2).Select(x => x.Name).ToArray();

                // SELECT Name FROM dbo.DomikType WHERE MaxCount = 2 ORDER BY Name
                return _context.DomikTypes.Where(x => x.MaxCount == 2).OrderBy(x => x.Name).Select(x => x.Name).ToArray();

                // SELECT TOP(1) * FROM dbo.DomikType WHERE LogicName = 'forge'
                _context.DomikTypes.SingleOrDefault(x => x.LogicName == "forge");

                // SELECT TOP(2) * FROM dbo.DomikType WHERE LogicName = 'forge'
                _context.DomikTypes.FirstOrDefault(x => x.LogicName == "forge");
            }

            if (1 == 0)
            {
                // UPDATE dbo.DomikType SET Name = 'Test1' WHERE LogicName = 'forge'
                var forge = _context.DomikTypes.First(x => x.LogicName == "forge");
                var prev = forge.Name;
                forge.Name = "Test" + DateTime.Now.Second;
                return new[] { prev };

                //INSERT INTO [DomikTypes] ([Id], [LogicName],[Name]) VALUES(8,...)
                var pyatietazhka2 = new Domiki.Web.Data.DomikType
                {
                    Id = 8,
                    Name = "Пятиэтажка",
                    LogicName = "pyatietazhka",
                };
                _context.DomikTypes.Add(pyatietazhka2);

                //  DELETE FROM dbo.DomikType WHERE Id = 1
                var a24 = _context.DomikTypes.First(x => x.Id == 1);
                _context.DomikTypes.Remove(a24);
            }

            if (1 == 0)
            {
                //SELECT [d].[Id], [d].[LogicName], [d].[MaxCount], [d].[Name], [d0].[DomikTypeId], [d0].[Value], [d0].[MaxManufactureCount], [d0].[UpgradeSeconds]
                //FROM[DomikTypes] AS[d]
                //LEFT JOIN[DomikTypeLevels] AS[d0] ON[d].[Id] = [d0].[DomikTypeId]
                //ORDER BY[d].[Id], [d0].[DomikTypeId]
                var atestm1 = _context.DomikTypes.Include(x => x.Levels).ToArray();

                var types23 = _context.DomikTypeLevels.ToArray();

                // SELECT[d].[DomikTypeId], [d].[Value], [d].[MaxManufactureCount], [d].[UpgradeSeconds], [d0].[Id], [d0].[LogicName], [d0].[MaxCount], [d0].[Name]
                //FROM[DomikTypeLevels] AS[d]
                //INNER JOIN[DomikTypes] AS[d0] ON[d].[DomikTypeId] = [d0].[Id]
                var types234 = _context.DomikTypeLevels.Join(
                    _context.DomikTypes,
                    x => x.DomikTypeId,
                    x => x.Id,
                    (level, type) => new { Level = level, Type = type }).ToArray();

                //SELECT[d].[DomikTypeId], [d].[Value], [d].[MaxManufactureCount], [d].[UpgradeSeconds], [d0].[Id], [d0].[LogicName], [d0].[MaxCount], [d0].[Name]
                //FROM[DomikTypeLevels] AS[d]
                //LEFT JOIN[DomikTypes] AS[d0] ON[d].[DomikTypeId] = [d0].[Id]
                var qry = _context.DomikTypeLevels.GroupJoin(
                  _context.DomikTypes,
                  foo => foo.DomikTypeId,
                  bar => bar.Id,
                  (x, y) => new { Foo = x, Bars = y })
               .SelectMany(
                   x => x.Bars.DefaultIfEmpty(),
                   (x, y) => new { Foo = x.Foo, Bar = y }).ToArray();

                foreach (var t in types234)
                {
                    //var type = _context.DomikTypes.First(x => x.Id == t.DomikTypeId);
                    var level = t.Level;
                    var type = t.Type;
                }
                return types234.Select(x => x.Level.Value + " " + x.Type.LogicName).ToArray();

                //SELECT[d].[Name] AS[UsergroupID], [d].[LogicName] AS[UsergroupName]
                //FROM[DomikTypes] AS[d]
                //LEFT JOIN[DomikTypeLevels] AS[d0] ON[d].[Id] = [d0].[DomikTypeId]
                var query = from u in _context.DomikTypes
                            join p in _context.DomikTypeLevels on u.Id equals p.DomikTypeId into gj
                            from x in gj.DefaultIfEmpty()
                            select new
                            {
                                UsergroupID = u.Name,
                                UsergroupName = u.LogicName,
                            };
                query.ToArray();

                //SELECT 1
                _context.Database.ExecuteSqlRaw("SELECT 1");

                var asd = _context.DomikTypes.Where(x => x.MaxCount == 2);
                //asd =  asd.Where(x => x.MaxCount > 1);
                //asd = asd.Where(x => x.MaxCount < 3);
                asd = SetParam(asd);
                asd.ToArray();
            }

            var items = new Item[]
            {
                new Item { Id = 1, Value = 1 },
                new Item {Id = 2, Value = 2},
            };
            var a = items.Where(x => x.Id == 1);
            var b = a.ToArray();

            return new string[] { "111" };
            //var content = _resourceManager.GetDomikTypes().Select(x => x.ToDto()).ToArray();
            //return new Response<DomikTypeDto[]>(content);
        }

        private IQueryable<Web.Data.DomikType> SetParam(IQueryable<Web.Data.DomikType> asd)
        {
            return asd.Where(x => x.MaxCount > -1);
        }

        [HttpGet]
        [Route("/System/TestAsync")]
        public async Task<string[]> GetDomikTypesAsync(CancellationToken token)
        {
            return await _context.DomikTypes.Select(x => x.Name).ToArrayAsync(token);

            //var content = _resourceManager.GetDomikTypes().Select(x => x.ToDto()).ToArray();
            //return new Response<DomikTypeDto[]>(content);
        }

        public class Item
        {
            private int _id;
            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }
            public int Value { get; set; }
        }
    }
}