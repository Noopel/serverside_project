import Link from "next/link";

const Header = () => {
  return (
    <header  className="flex justify-end items-end min-h-64 bg-[#6A90A0] text-white text-6xl font-bold">
      <Link href={"/"}>BIBLIOTHÈQUE PUBLIQUE</Link>
    </header>
  );
};

export default Header;
