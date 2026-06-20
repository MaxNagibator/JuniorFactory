const REPO = "https://github.com/MaxNagibator/JuniorFactory/tree/master/";

const LESSONS = [
  {n:"01", slug:"JuniorFactory.Lesson01.Base",        title:"Знакомство с C#",        desc:"Типы данных, циклы, условия, объекты и массивы.",            tags:["C#",".NET FRAMEWORK"], win:true},
  {n:"02", slug:"JuniorFactory.Lesson02.DataStorage", title:"Хранение данных",        desc:"Файлы и простые интерфейсы на Windows Forms.",               tags:["WINFORMS","JSON"], win:true},
  {n:"03", slug:"JuniorFactory.Lesson03.Git",         title:"Основы Git",             desc:"Коммиты, ветки, слияния и решение конфликтов.",              tags:["GIT"]},
  {n:"04", slug:"JuniorFactory.Lesson04.Postgres",    title:"Основы PostgreSQL",      desc:"Установка, таблицы и запросы к реляционной БД.",             tags:["POSTGRESQL"], docs:true},
  {n:"05", slug:"JuniorFactory.Lesson05.UnitTests",   title:"Юнит-тестирование",      desc:"Пишем тесты в .NET — одна библиотека двумя фреймворками.",   tags:["MSTEST","NUNIT"]},
  {n:"06", slug:"JuniorFactory.Lesson06.Frontend",    title:"HTML, CSS и JavaScript", desc:"Структура страниц, стили и интерактивность.",                tags:["HTML","CSS","JS"]},
  {n:"07", slug:"JuniorFactory.Lesson07.OCP",         title:"OCP и «Стратегия»",      desc:"Принцип открытости/закрытости на консольном примере.",       tags:["C#","SOLID"]},
  {n:"08", slug:"JuniorFactory.Lesson08.WebApi",      title:"ASP.NET Web API",        desc:"Контроллеры, тестирование и безопасность.",                  tags:["ASP.NET CORE"]},
  {n:"09", slug:"JuniorFactory.Lesson09.Files",       title:"Работа с файлами",       desc:"Анализатор файлов на диске и файловая система.",             tags:["FILE I/O"], win:true},
  {n:"10", slug:"JuniorFactory.Lesson10.XmlCSV",      title:"XML и CSV",              desc:"Парсинг и сохранение данных в двух форматах.",               tags:["XML","CSV"]},
  {n:"11", slug:"JuniorFactory.Lesson11.Threads",     title:"Асинхронность",          desc:"Многопоточность, async-операции и отмена задач.",            tags:["ASYNC","THREADS"]},
  {n:"12", slug:"JuniorFactory.Lesson12.CI_CD",       title:"CI/CD",                  desc:"Зачем нужна автоматизация сборки и доставки.",               tags:["CI/CD","ACTIONS"], docs:true},
  {n:"13", slug:"JuniorFactory.Lesson13.LinqEf",      title:"EF / ORM",               desc:"Entity Framework и LINQ на мини-игре «Домики».",             tags:["EF CORE","REACT"]},
  {n:"14", slug:"JuniorFactory.Lesson14.Selenium",    title:"Selenium",               desc:"Автоматизация и тестирование браузера.",                     tags:["SELENIUM"]},
  {n:"15", slug:"JuniorFactory.Lesson15.Playwright",  title:"Playwright",             desc:"Современный инструмент UI-тестирования.",                    tags:["PLAYWRIGHT"]},
];

const grid = document.getElementById("grid");
grid.innerHTML = LESSONS.map(l => `
  <a class="mod" href="${REPO}${l.slug}" target="_blank" rel="noopener">
    <div class="mod__top">
      <span class="mod__no">${l.n}</span>
      <span class="mod__flags">
        ${l.win ? '<span class="flag win">WINDOWS</span>' : ''}
        ${l.docs ? '<span class="flag docs">ТЕОРИЯ</span>' : ''}
      </span>
    </div>
    <h3 class="mod__title">${l.title}</h3>
    <p class="mod__desc">${l.desc}</p>
    <div class="mod__tags">${l.tags.map(t => `<span>${t}</span>`).join("")}</div>
    <div class="mod__cta">Открыть урок <span class="arr">→</span></div>
  </a>`).join("");

const beltWords = ["C#",".NET","GIT","POSTGRESQL","ТЕСТЫ","HTML/CSS/JS","SOLID","ASP.NET","ФАЙЛЫ","XML/CSV","ASYNC","CI/CD","EF CORE","SELENIUM","PLAYWRIGHT"];
const beltHtml = '<span>' + beltWords.map(w => `${w}<i>◆</i>`).join("") + '</span>';
document.getElementById("belt").innerHTML = beltHtml + beltHtml;

const io = new IntersectionObserver((entries) => {
  entries.forEach((e) => {
    if (e.isIntersecting) {
      const i = [...grid.children].indexOf(e.target);
      e.target.style.transitionDelay = Math.min(i, 9) * 55 + "ms";
      e.target.classList.add("in");
      io.unobserve(e.target);
    }
  });
}, { threshold:.15 });
[...grid.children].forEach(c => io.observe(c));

document.getElementById("year").textContent = new Date().getFullYear();
