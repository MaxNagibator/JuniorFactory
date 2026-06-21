const grid = document.getElementById("grid");

const io = new IntersectionObserver((entries) => {
  entries.forEach((e) => {
    if (e.isIntersecting) {
      const i = [...grid.children].indexOf(e.target);
      e.target.style.transitionDelay = Math.min(i, 9) * 55 + "ms";
      e.target.classList.add("in");
      io.unobserve(e.target);
    }
  });
}, { threshold: .15 });
[...grid.children].forEach(c => io.observe(c));

const cards = [...grid.children];
const search = document.getElementById("lessonSearch");
const count = document.getElementById("lessonCount");
const empty = document.getElementById("gridEmpty");

function plural(n) {
  const a = n % 10, b = n % 100;
  if (a === 1 && b !== 11) return "урок";
  if (a >= 2 && a <= 4 && (b < 10 || b >= 20)) return "урока";
  return "уроков";
}
function filter() {
  const q = search.value.trim().toLowerCase();
  let shown = 0;
  cards.forEach(c => {
    const match = !q || c.textContent.toLowerCase().includes(q);
    c.classList.toggle("hide", !match);
    if (match) shown++;
  });
  count.textContent = shown + " " + plural(shown);
  empty.classList.toggle("show", shown === 0);
}
search.addEventListener("input", filter);
filter();

document.getElementById("year").textContent = new Date().getFullYear();

const copyBtn = document.getElementById("cryptoCopy");
if (copyBtn) {
  copyBtn.addEventListener("click", async () => {
    try {
      await navigator.clipboard.writeText(copyBtn.dataset.addr);
      copyBtn.textContent = "Скопировано";
      copyBtn.classList.add("ok");
      setTimeout(() => { copyBtn.textContent = "Копировать"; copyBtn.classList.remove("ok"); }, 1600);
    } catch { /* clipboard недоступен (file:// или старый браузер) */ }
  });
}
