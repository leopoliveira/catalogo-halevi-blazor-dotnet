import Link from "next/link";

export default function Header() {
  return (
    <header className="flex flex-row items-center justify-between p-8 z-30 shadow-sm rounded-md bg-slate-50">
      <Link
        href={"/"}
        id="logo">
        Logo
      </Link>

      <Link
        href={"/cart"}
        id="go-to-cart">
        Shopping Cart
      </Link>
    </header>
  );
}
