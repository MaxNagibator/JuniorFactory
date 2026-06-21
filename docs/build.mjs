import { readFile, writeFile, mkdir, rm } from "node:fs/promises";
import { minify } from "html-minifier-terser";
import * as sass from "sass";
import MarkdownIt from "markdown-it";
import { createHighlighter } from "shiki";

const OUT = "dist";
const SITE = "https://maxnagibator.github.io/JuniorFactory";
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
  {n:"16", slug:"JuniorFactory.Lesson16.GitReset",    title:"Git Reset и Revert",     desc:"Откат изменений: reset, revert и работа с коммитами.",        tags:["GIT"]},
  {n:"17", slug:"JuniorFactory.Lesson17.EfCoreAudit", title:"Аудит в EF Core",        desc:"Две стратегии логирования изменений данных через EF Core.",  tags:["EF CORE","AUDIT"]},
];

const beltWords = ["C#",".NET","GIT","POSTGRESQL","ТЕСТЫ","HTML/CSS/JS","SOLID","ASP.NET","ФАЙЛЫ","XML/CSV","ASYNC","CI/CD","EF CORE","SELENIUM","PLAYWRIGHT","GIT RESET","EF AUDIT"];

const CODE = {
  "01": ["JuniorFactory.Lesson01/Program.cs"],
  "03": ["JuniorFactory.Lesson03/Program.cs"],
  "07": ["JuniorFactory.Lesson07/Program.cs"],
  "10": ["JuniorFactory.Lesson10/XmlPomogator.cs"],
  "11": ["JuniorFactory.Lesson11/AsyncWorker.cs", "JuniorFactory.Lesson11/ParallelWorker.cs"],
};
const EXT_LANG = { cs:"csharp", js:"javascript", html:"html", css:"css", json:"json", xml:"xml", sql:"sql" };

const THEME = "vitesse-dark";
const highlighter = await createHighlighter({ themes: [THEME], langs: Object.values(EXT_LANG).concat("bash") });
const LANG_LOADED = new Set(highlighter.getLoadedLanguages());
const codeToHtml = (code, lang) => highlighter.codeToHtml(code, { lang: LANG_LOADED.has(lang) ? lang : "text", theme: THEME });

const mdit = new MarkdownIt({
  html: false, linkify: false, typographer: false,
  highlight: (code, lang) => codeToHtml(code, lang),
});
const TOTAL = LESSONS.length;

const esc = s => String(s).replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;").replace(/"/g, "&quot;");
const jsonInline = obj => JSON.stringify(obj).replace(/</g, "\\u003c");

function plural(n, forms) {
  const n10 = n % 10, n100 = n % 100;
  if (n10 === 1 && n100 !== 11) return forms[0];
  if (n10 >= 2 && n10 <= 4 && (n100 < 10 || n100 >= 20)) return forms[1];
  return forms[2];
}

function timeToSeconds(tc) {
  const p = tc.split(":").map(Number);
  return p.length === 3 ? p[0] * 3600 + p[1] * 60 + p[2] : p[0] * 60 + p[1];
}

function extractVideoId(readme) {
  const m = readme.match(/\[[^\]]*\]\(https:\/\/www\.youtube\.com\/watch\?v=([a-zA-Z0-9_-]+)/);
  return m ? m[1] : null;
}

function extractRutubeId(readme) {
  const m = readme.match(/rutube\.ru\/(?:video|play\/embed)\/([a-f0-9]{16,})/i);
  return m ? m[1] : null;
}

function extractVk(readme) {
  const m = readme.match(/vk(?:video)?\.(?:ru|com)\/video(-?\d+)_(\d+)/i);
  return m ? { o: m[1], i: m[2] } : null;
}

function parseVideoMd(text) {
  const blocks = [];
  let cur = null;
  for (const raw of text.split(/\r?\n/)) {
    const line = raw.trim();
    const h = /^###\s+(\d{2}:\d{2}(?::\d{2})?)\s+(.*)$/.exec(line);
    if (h) {
      let title = h[2].trim();
      const lm = /^\[([^\]]*)\]/.exec(title);
      if (lm) title = lm[1].trim();
      cur = { s: timeToSeconds(h[1]), t: h[1], title, b: [] };
      blocks.push(cur);
      continue;
    }
    const bm = /^[-•]\s+(.*)$/.exec(line);
    if (bm && cur) cur.b.push(bm[1].trim());
  }
  return blocks;
}

function renderReadme(text) {
  const lines = text.split(/\r?\n/);
  const titleLine = lines.find(l => /^#\s+/.test(l));
  const title = titleLine ? titleLine.replace(/^#\s+/, "").trim() : "";
  const titleShort = title.replace(/^\d+\.\s*/, "");

  const hr = lines.findIndex(l => /^---\s*$/.test(l));
  const body = hr === -1 ? lines : lines.slice(0, hr);

  const kept = [];
  let skip = false;
  for (const l of body) {
    if (/^#\s+/.test(l)) continue;
    const m = /^##\s+(.*)$/.exec(l);
    if (m) {
      const name = m[1].trim();
      skip = /видео/i.test(name);
      if (skip || /краткое описание/i.test(name)) continue;
      kept.push(l);
      continue;
    }
    if (!skip) kept.push(l);
  }
  return { title, titleShort, descHtml: mdit.render(kept.join("\n").trim()) };
}

const SPRITE = `<svg width="0" height="0" aria-hidden="true" focusable="false" style="position:absolute">
<symbol id="i-play" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M5 5a2 2 0 0 1 3.008-1.728l11.997 6.998a2 2 0 0 1 .003 3.458l-12 7A2 2 0 0 1 5 19z"/></symbol>
<symbol id="i-play-fill" viewBox="0 0 24 24" fill="currentColor"><path d="M5 5a2 2 0 0 1 3.008-1.728l11.997 6.998a2 2 0 0 1 .003 3.458l-12 7A2 2 0 0 1 5 19z"/></symbol>
<symbol id="i-arrow" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M5 12h14"/><path d="m12 5 7 7-7 7"/></symbol>
<symbol id="i-arrow-left" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M19 12H5"/><path d="m12 19-7-7 7-7"/></symbol>
<symbol id="i-diamond" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M2.7 10.3a2.41 2.41 0 0 0 0 3.41l7.59 7.59a2.41 2.41 0 0 0 3.41 0l7.59-7.59a2.41 2.41 0 0 0 0-3.41l-7.59-7.59a2.41 2.41 0 0 0-3.41 0Z"/></symbol>
<symbol id="i-github" viewBox="0 0 24 24" fill="currentColor"><path d="M12 .297c-6.63 0-12 5.373-12 12 0 5.303 3.438 9.8 8.205 11.385.6.113.82-.258.82-.577 0-.285-.01-1.04-.015-2.04-3.338.724-4.042-1.61-4.042-1.61C4.422 18.07 3.633 17.7 3.633 17.7c-1.087-.744.084-.729.084-.729 1.205.084 1.838 1.236 1.838 1.236 1.07 1.835 2.809 1.305 3.495.998.108-.776.417-1.305.76-1.605-2.665-.3-5.466-1.332-5.466-5.93 0-1.31.465-2.38 1.235-3.22-.135-.303-.54-1.523.105-3.176 0 0 1.005-.322 3.3 1.23.96-.267 1.98-.399 3-.405 1.02.006 2.04.138 3 .405 2.28-1.552 3.285-1.23 3.285-1.23.645 1.653.24 2.873.12 3.176.765.84 1.23 1.91 1.23 3.22 0 4.61-2.805 5.625-5.475 5.92.42.36.81 1.096.81 2.22 0 1.606-.015 2.896-.015 3.286 0 .315.21.69.825.57C20.565 22.092 24 17.592 24 12.297c0-6.627-5.373-12-12-12"/></symbol>
</svg>`;

const HEADER = `<header><div class="wrap bar">
<a class="brand" href="../index.html"><span class="mark">JF</span><span><b>Юниорная Мануфактура</b><small>EST. 2026 · .NET ЦЕХ</small></span></a>
<nav>
<a class="nav-desk" href="../index.html#lessons">Уроки</a>
<a class="nav-desk" href="../index.html#operator">Ведущий</a>
<a class="cta" href="https://www.youtube.com/playlist?list=PLgBM0sSyvWQX1amvtC8-rsmDEwKREdd0t" target="_blank" rel="noopener"><svg class="ico" aria-hidden="true"><use href="#i-play"/></svg>Плейлист</a>
</nav>
</div></header>`;

const FOOTER = `<footer><div class="hazard"></div><div class="wrap foot">
<div class="sign"><div class="mark">JUNIOR FACTORY</div><p>Собрано на конвейере · MIT License<br>© <span id="year"></span> MaxNagibator (Максим Грицина)<br>Сделано для начинающих .NET-разработчиков.</p></div>
<div class="col"><h4>Курс</h4>
<a href="../index.html#lessons">Все уроки</a>
<a href="https://github.com/MaxNagibator/JuniorFactory" target="_blank" rel="noopener">Репозиторий</a>
<a href="https://www.youtube.com/playlist?list=PLgBM0sSyvWQX1amvtC8-rsmDEwKREdd0t" target="_blank" rel="noopener">Плейлист YouTube</a>
<a href="https://rutube.ru/plst/626607" target="_blank" rel="noopener">Плейлист Rutube</a></div>
<div class="col"><h4>Ведущий</h4>
<a href="https://www.youtube.com/@bobito217" target="_blank" rel="noopener">YouTube-канал</a>
<a href="https://t.me/bobito217" target="_blank" rel="noopener">Telegram</a>
<a href="https://www.twitch.tv/bobito217" target="_blank" rel="noopener">Twitch</a>
<a href="http://bob217.ru/" target="_blank" rel="noopener">Сайт поделок</a></div>
</div></footer>`;

function navCard(l, dir) {
  if (!l) {
    const lab = dir === "prev" ? "Начало линии" : "Конец линии";
    return `<span class="lnav ${dir} is-disabled"><span class="dir">${dir === "prev" ? "Старт" : "Финиш"}</span><span class="name">${lab}</span></span>`;
  }
  const arrow = dir === "prev" ? "i-arrow-left" : "i-arrow";
  const label = dir === "prev" ? "Предыдущая станция" : "Следующая станция";
  const dirHtml = dir === "prev"
    ? `<svg class="ico" aria-hidden="true"><use href="#${arrow}"/></svg> ${label}`
    : `${label} <svg class="ico" aria-hidden="true"><use href="#${arrow}"/></svg>`;
  return `<a class="lnav ${dir}" href="${l.n}.html"><span class="dir">${dirHtml}</span><span class="name">${l.n}. ${esc(l.title)}</span></a>`;
}

function tocSector(blocks) {
  const count = blocks.length;
  return `<section class="sector toc" aria-label="Интерактивный конспект">
<div class="sector-head"><span class="num">// СЕКТОР B</span><span class="title">Технологическая карта</span><span class="meta">${count} ${plural(count, ["операция", "операции", "операций"])}</span></div>
<div class="toc-gauge"><div class="g-top"><span class="g-lab">Обработано по навигации</span><span class="g-val"><span id="gaugeDone">0</span><small>&thinsp;/&thinsp;<span id="gaugeTotal">${count}</span></small></span></div>
<div class="g-bar" role="progressbar" aria-valuemin="0" aria-valuemax="${count}" aria-valuenow="0" id="gaugeBar"><span class="g-fill" id="gaugeFill"></span></div></div>
<div class="toc-tools"><input class="toc-search" id="tocSearch" type="search" placeholder="Поиск по операциям…" aria-label="Поиск по конспекту"><span class="toc-count" id="tocCount">${count}</span></div>
<ul class="toc-list" id="tocList"><span class="belt-done" id="beltDone" aria-hidden="true"></span></ul>
<div class="toc-empty" id="tocEmpty">// НИЧЕГО НЕ НАЙДЕНО</div>
</section>`;
}

const NO_NOTES = `<section class="sector" aria-label="Конспект">
<div class="sector-head"><span class="num">// СЕКТОР B</span><span class="title">Технологическая карта</span><span class="meta">—</span></div>
<div class="no-notes">Интерактивный конспект для этого урока пока не готов — <b>смотрите видео целиком</b>.</div>
</section>`;

function codeSector(files, ghUrl) {
  const meta = files.length === 1 ? esc(files[0].name) : `${files.length} ${plural(files.length, ["файл", "файла", "файлов"])}`;
  const body = files.map(f => `<figure class="code-file"><figcaption>${esc(f.name)}</figcaption>${f.html}</figure>`).join("");
  return `<section class="sector" aria-label="Исходный код урока">
<div class="sector-head"><span class="num">// СЕКТОР D</span><span class="title">Исходный код</span><span class="meta">${meta}</span></div>
<div class="code-body">${body}<a class="code-more" href="${ghUrl}" target="_blank" rel="noopener"><svg class="ico" aria-hidden="true"><use href="#i-github"/></svg>Весь код урока на GitHub</a></div>
</section>`;
}

function lessonPage(l, ctx, css, js) {
  const { title, titleShort, descHtml, videoId, rutubeId, vk, blocks, codeFiles, prev, next } = ctx;
  const chrono = blocks.length ? blocks[blocks.length - 1].t : null;
  const fullTitle = `${title} — Юниорная Мануфактура`;
  const thumb = `https://i.ytimg.com/vi/${videoId}/hqdefault.jpg`;
  const ghUrl = REPO + l.slug;
  const desc = `Урок ${l.n} курса «Юниорная Мануфактура»: ${titleShort}. Видео + интерактивный конспект и код урока.`;

  const spec = [`СТАНЦИЯ ${l.n} / ${TOTAL}`, "ПАРТИЯ: НАЧИНАЮЩИЕ"];
  if (chrono) spec.push(`ХРОНОМЕТРАЖ: ${chrono}`);
  else if (l.docs) spec.push("ФОРМАТ: ТЕОРИЯ");
  const specHtml = spec.map(s => `<span>${s}</span>`).join("");
  const tagsHtml = l.tags.map(t => `<span class="tag-chip">${esc(t)}</span>`).join("");
  const tapeRight = `${l.n}. ${l.tags.join(" / ")}${chrono ? " · " + chrono : ""}`;

  const lessonData = jsonInline({ videoId, rutubeId, vk, title, blocks });
  const altBtns = (rutubeId ? `<button type="button" class="src-btn" data-src="rt">RuTube</button>` : "")
    + (vk ? `<button type="button" class="src-btn" data-src="vk">VK Видео</button>` : "");
  const srcSwitch = altBtns ? `<div class="src-switch" id="srcSwitch" role="group" aria-label="Источник видео"><button type="button" class="src-btn is-active" data-src="yt">YouTube</button>${altBtns}</div>` : "";

  return `<!doctype html>
<html lang="ru">
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<script>document.documentElement.className="js"</script>
<title>${esc(fullTitle)}</title>
<meta name="description" content="${esc(desc)}">
<link rel="canonical" href="${SITE}/lessons/${l.n}.html">
<meta property="og:type" content="article">
<meta property="og:url" content="${SITE}/lessons/${l.n}.html">
<meta property="og:site_name" content="Юниорная Мануфактура">
<meta property="og:locale" content="ru_RU">
<meta property="og:title" content="${esc(fullTitle)}">
<meta property="og:description" content="${esc(desc)}">
<meta property="og:image" content="${thumb}">
<meta name="twitter:card" content="summary_large_image">
<meta name="twitter:title" content="${esc(fullTitle)}">
<meta name="twitter:description" content="${esc(desc)}">
<meta name="twitter:image" content="${thumb}">
<link rel="icon" href="data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 32 32'%3E%3Crect width='32' height='32' fill='%230b1118'/%3E%3Ctext x='16' y='23' font-family='Arial Black,sans-serif' font-size='20' fill='%23ff8a1e' text-anchor='middle'%3EJF%3C/text%3E%3C/svg%3E">
<link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link rel="preconnect" href="https://i.ytimg.com">
<link rel="preconnect" href="https://www.youtube-nocookie.com">
<link href="https://fonts.googleapis.com/css2?family=Russo+One&family=Oswald:wght@400;500;600;700&family=PT+Sans:wght@400;700&family=JetBrains+Mono:wght@400;500&display=swap" rel="stylesheet">
<style>${css}</style>
</head>
<body>
${SPRITE}
${HEADER}
<div class="hazard"></div>
<main>
<section class="order"><div class="wrap">
<nav class="crumbs" aria-label="Навигация по курсу"><a href="../index.html#lessons">Линия сборки</a><span class="sep">/</span><span class="cur">Станция ${l.n}</span><span class="sep">/</span><span class="mono">НАРЯД № JF-${l.n}</span></nav>
<div class="order-head">
<div class="station-no">${l.n}<span class="tag">STATION · ${l.n}/${TOTAL}</span></div>
<div class="order-meta">
<div class="spec">${specHtml}</div>
<h1>${esc(titleShort)}</h1>
<div class="order-tags">${tagsHtml}<a class="gh-link" href="${ghUrl}" target="_blank" rel="noopener"><svg class="ico" aria-hidden="true"><use href="#i-github"/></svg>Код урока на GitHub</a></div>
</div>
</div>
<div class="sheet">
<div class="col-left">
<section class="sector" aria-label="Видео урока">
<div class="sector-head"><span class="num">// СЕКТОР A</span><span class="title">Видеозапись смены</span><span class="meta">YT · ${esc(videoId)}</span></div>
<div class="player-body">
<div class="player-status"><span>ПУЛЬТ ОПЕРАТОРА</span><span class="ps-state" id="psState">ГОТОВ К ЗАПУСКУ</span></div>
${srcSwitch}
<div class="player" id="player">
<button class="facade" id="facade" type="button" aria-label="Запустить видео: ${esc(title)}">
<img src="${thumb}" alt="" loading="lazy" width="480" height="360">
<span class="corner tl" aria-hidden="true"></span><span class="corner br" aria-hidden="true"></span>
<span class="play" aria-hidden="true"><svg viewBox="0 0 24 24"><use href="#i-play-fill"/></svg></span>
<span class="tape" aria-hidden="true"><span class="live">&#9679; ЗАПИСЬ ЛИНИИ</span><span>${esc(tapeRight)}</span></span>
</button>
</div>
<div class="now-playing" id="nowPlaying" hidden><span class="lab">Текущий блок:</span><span class="np-time" id="npTime">00:00</span><span class="np-title" id="npTitle"></span></div>
</div>
</section>
<section class="sector" aria-label="Описание урока">
<div class="sector-head"><span class="num">// СЕКТОР C</span><span class="title">Спецификация наряда</span><span class="meta">README.md</span></div>
<div class="readme-body">${descHtml}</div>
</section>
${codeFiles.length ? codeSector(codeFiles, ghUrl) : ""}
</div>
<div class="col-right">${blocks.length ? tocSector(blocks) : NO_NOTES}</div>
</div>
<nav class="lesson-nav" aria-label="Соседние уроки">
${navCard(prev, "prev")}
<a class="lnav toc-link" href="../index.html#lessons"><span class="name"><svg class="ico" aria-hidden="true"><use href="#i-diamond"/></svg> Оглавление</span></a>
${navCard(next, "next")}
</nav>
</div></section>
</main>
${FOOTER}
<script>var LESSON=${lessonData};
${js}</script>
</body>
</html>`;
}

const gridHtml = LESSONS.map(l => `<a class="mod" href="lessons/${l.n}.html"><div class="mod__top"><span class="mod__no">${l.n}</span><span class="mod__flags">${l.win ? '<span class="flag win">WINDOWS</span>' : ''}${l.docs ? '<span class="flag docs">ТЕОРИЯ</span>' : ''}</span></div><h3 class="mod__title">${l.title}</h3><p class="mod__desc">${l.desc}</p><div class="mod__tags">${l.tags.map(t => `<span>${t}</span>`).join("")}</div><div class="mod__cta">Открыть урок <svg class="ico arr" aria-hidden="true"><use href="#i-arrow"/></svg></div></a>`).join("");

const sep = '<svg class="ico belt-sep" aria-hidden="true"><use href="#i-diamond"/></svg>';
const beltSpan = "<span>" + beltWords.map(w => w + sep).join("") + "</span>";
const beltHtml = beltSpan + beltSpan;

const minOpts = {
  collapseWhitespace: true,
  removeComments: true,
  removeRedundantAttributes: true,
  useShortDoctype: true,
  minifyCSS: true,
  minifyJS: true,
};

await rm(OUT, { recursive: true, force: true });
await mkdir(`${OUT}/lessons`, { recursive: true });

const [indexSrc, mainJs] = await Promise.all([readFile("index.html", "utf8"), readFile("main.js", "utf8")]);
const cssLanding = sass.compile("styles.scss", { style: "compressed" }).css;
const cssLesson = sass.compile("lesson.scss", { style: "compressed" }).css;
const lessonJs = await readFile("lesson.js", "utf8");

const indexInlined = indexSrc
  .replace('<link rel="stylesheet" href="styles.css">', `<style>${cssLanding}</style>`)
  .replace('<script src="main.js" defer></script>', `<script>${mainJs}</script>`)
  .replace("<!--grid-->", gridHtml)
  .replace("<!--belt-->", beltHtml);
await writeFile(`${OUT}/index.html`, await minify(indexInlined, minOpts));

let built = 0;
for (let i = 0; i < LESSONS.length; i++) {
  const l = LESSONS[i];
  let readme;
  try {
    readme = await readFile(`../${l.slug}/README.md`, "utf8");
  } catch {
    console.warn(`! ${l.slug}: README.md не найден, пропуск`);
    continue;
  }
  if (readme.charCodeAt(0) === 0xFEFF) readme = readme.slice(1);
  const videoId = extractVideoId(readme);
  if (!videoId) {
    console.warn(`! ${l.slug}: videoId не найден, пропуск`);
    continue;
  }
  const rutubeId = extractRutubeId(readme);
  const vk = extractVk(readme);
  const { title, titleShort, descHtml } = renderReadme(readme);
  let blocks = [];
  try {
    blocks = parseVideoMd(await readFile(`../${l.slug}/video.md`, "utf8"));
  } catch { /* no video.md — конспекта не будет */ }

  const codeFiles = [];
  for (const rel of CODE[l.n] || []) {
    try {
      let src = (await readFile(`../${l.slug}/${rel}`, "utf8")).replace(/[\r\n]+$/, "");
      if (src.charCodeAt(0) === 0xFEFF) src = src.slice(1);
      const ext = rel.split(".").pop().toLowerCase();
      codeFiles.push({ name: rel.split("/").pop(), html: codeToHtml(src, EXT_LANG[ext] || "text") });
    } catch {
      console.warn(`! ${l.slug}: ${rel} не найден, код пропущен`);
    }
  }

  const ctx = { title, titleShort, descHtml, videoId, rutubeId, vk, blocks, codeFiles, prev: LESSONS[i - 1] || null, next: LESSONS[i + 1] || null };
  const html = await minify(lessonPage(l, ctx, cssLesson, lessonJs), minOpts);
  await writeFile(`${OUT}/lessons/${l.n}.html`, html);
  built++;
}

const sitemapUrls = [`${SITE}/`, ...LESSONS.map(l => `${SITE}/lessons/${l.n}.html`)];
const sitemap = `<?xml version="1.0" encoding="UTF-8"?>\n<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">\n${sitemapUrls.map(u => `<url><loc>${u}</loc></url>`).join("\n")}\n</urlset>\n`;
await writeFile(`${OUT}/sitemap.xml`, sitemap);

const idxKb = (Buffer.byteLength(await readFile(`${OUT}/index.html`)) / 1024).toFixed(1);
console.log(`built ${OUT}/index.html — ${idxKb} kb`);
console.log(`built ${built} lesson pages → ${OUT}/lessons/`);
console.log(`built ${OUT}/sitemap.xml — ${sitemapUrls.length} urls`);
