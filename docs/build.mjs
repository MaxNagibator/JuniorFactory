import { readFile, writeFile, mkdir, rm } from "node:fs/promises";
import { minify } from "html-minifier-terser";
import * as sass from "sass";

const OUT = "dist";

await rm(OUT, { recursive: true, force: true });
await mkdir(OUT, { recursive: true });

const [html, js] = await Promise.all([
  readFile("index.html", "utf8"),
  readFile("main.js", "utf8"),
]);
const css = sass.compile("styles.scss", { style: "compressed" }).css;

const inlined = html
  .replace('<link rel="stylesheet" href="styles.css">', `<style>${css}</style>`)
  .replace('<script src="main.js" defer></script>', `<script>${js}</script>`);

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
