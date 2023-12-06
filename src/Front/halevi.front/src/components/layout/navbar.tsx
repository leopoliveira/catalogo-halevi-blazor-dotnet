export default function Navbar() {
  return (
    <nav className="flex flex-col items-center justify-center pr-4 pt-4 pb-4 sm:w-32 md:w-64 text-center z-30 shadow-sm rounded-md bg-slate-50">
      <ul className="flex flex-col items-center justify-center gap-4">
        <li className="cursor-pointer">Categoria 1</li>
        <li className="cursor-pointer">Categoria 2</li>
        <li className="cursor-pointer">Categoria 3</li>
        <li className="cursor-pointer">Categoria 4</li>
      </ul>
    </nav>
  );
}
