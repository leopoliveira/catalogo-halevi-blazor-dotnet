import ProductCard from "../product/product-card";

export default function Main() {
  return (
    <main className="ml-2 flex-1 text-center pr-4 pt-4 pb-4 z-30 shadow-sm rounded-md bg-slate-50">
      <div className="grid grid-cols-1 md:grid-cols-2 min-auto lg:grid-cols-3 min-auto gap-4">
        <ProductCard />
        <ProductCard />
        <ProductCard />
        <ProductCard />
        <ProductCard />
        <ProductCard />
        <ProductCard />
        <ProductCard />
        <ProductCard />
        <ProductCard />
        <ProductCard />
        <ProductCard />
      </div>
    </main>
  );
}
