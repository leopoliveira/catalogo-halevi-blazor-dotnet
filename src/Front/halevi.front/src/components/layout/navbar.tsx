export default function Navbar() {
  return (
    <nav className="flex mb-4 items-center justify-center p-4 text-center z-30 shadow-sm rounded-md bg-slate-50">
      <ul className="flex flex-row items-center justify-center gap-4">
        <li className="cursor-pointer">Categoria 1</li>
        <li className="cursor-pointer">Categoria 2</li>
        <li className="cursor-pointer">Categoria 3</li>
        <li className="cursor-pointer">Categoria 4</li>
      </ul>
    </nav>
  );
}
