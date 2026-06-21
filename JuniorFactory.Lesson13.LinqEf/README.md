# 13. EF/ORM

## Краткое описание

Самый большой проект курса – бэкенд браузерной игры «Домики» на ASP.NET Core и Entity Framework Core. Разбираем, что
такое ORM, пишем LINQ-запросы вместо ручного SQL, делаем миграции. Игру крутит фоновый сервис, который копит ресурсы
по таймеру. Спереди прикручен React-фронт.

## Что нужно

- **SQL Server** (хватит и Express) – строка подключения `DefaultConnection` в `appsettings.json` смотрит на
  `localhost\sqlexpress`.
- **Node.js** – React-фронт из `ClientApp/` собирается автоматически при `dotnet run` (Debug).

## Видео

Видео-урок по этой теме:
[.net помойка / JuniorFactory / 13. Linq + Entity Framework](https://www.youtube.com/watch?v=GwE6bdhg6hg)

Резервная копия (Rutube): [13. Linq + Entity Framework](https://rutube.ru/video/598303f1325e5cccef64780b3c7c9737/)

Резервная копия (VK Видео): [13. Linq + Entity Framework](https://vkvideo.ru/video-227746634_456239048)

---

[← 12. CI/CD](../JuniorFactory.Lesson12.CI_CD) · [Оглавление](../README.md) · [14. Selenium →](../JuniorFactory.Lesson14.Selenium)
