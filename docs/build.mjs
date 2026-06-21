import { readFile, writeFile, mkdir, rm } from "node:fs/promises";
import { minify } from "html-minifier-terser";
import * as sass from "sass";

const OUT = "dist";

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

const beltWords = ["C#",".NET","GIT","POSTGRESQL","ТЕСТЫ","HTML/CSS/JS","SOLID","ASP.NET","ФАЙЛЫ","XML/CSV","ASYNC","CI/CD","EF CORE","SELENIUM","PLAYWRIGHT"];

const gridHtml = LESSONS.map(l => `<a class="mod" href="${REPO}${l.slug}" target="_blank" rel="noopener"><div class="mod__top"><span class="mod__no">${l.n}</span><span class="mod__flags">${l.win ? '<span class="flag win">WINDOWS</span>' : ''}${l.docs ? '<span class="flag docs">ТЕОРИЯ</span>' : ''}</span></div><h3 class="mod__title">${l.title}</h3><p class="mod__desc">${l.desc}</p><div class="mod__tags">${l.tags.map(t => `<span>${t}</span>`).join("")}</div><div class="mod__cta">Открыть урок <svg class="ico arr" aria-hidden="true"><use href="#i-arrow"/></svg></div></a>`).join("");

const sep = '<svg class="ico belt-sep" aria-hidden="true"><use href="#i-diamond"/></svg>';
const beltSpan = "<span>" + beltWords.map(w => w + sep).join("") + "</span>";
const beltHtml = beltSpan + beltSpan;

await rm(OUT, { recursive: true, force: true });
await mkdir(OUT, { recursive: true });

const [html, js] = await Promise.all([
  readFile("index.html", "utf8"),
  readFile("main.js", "utf8"),
]);
const css = sass.compile("styles.scss", { style: "compressed" }).css;

const inlined = html
  .replace('<link rel="stylesheet" href="styles.css">', `<style>${css}</style>`)
  .replace('<script src="main.js" defer></script>', `<script>${js}</script>`)
  .replace("<!--grid-->", gridHtml)
  .replace("<!--belt-->", beltHtml);

const minified = await minify(inlined, {
  collapseWhitespace: true,
  removeComments: true,
  removeRedundantAttributes: true,
  useShortDoctype: true,
  minifyCSS: true,
  minifyJS: true,
});

await writeFile(`${OUT}/index.html`, minified);

const kb = (Buffer.byteLength(minified) / 1024).toFixed(1);
const raw = (Buffer.byteLength(html + css + js) / 1024).toFixed(1);
console.log(`built ${OUT}/index.html — ${kb} kb (from ${raw} kb source)`);
