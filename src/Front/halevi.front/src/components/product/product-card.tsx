import Image from "next/image";

export default function ProductCard() {
  return (
    <>
      <div className="max-w-sm rounded overflow-hidden shadow-lg bg-white">
        <Image
          src="https://via.placeholder.com/75"
          alt="title"
          width={500}
          height={300}
          objectFit="cover"
        />
        <div className="px-6 py-4">
          <div className="font-bold text-xl mb-2">{"Product 1"}</div>
          <div className="font-bold text-xl mb-2">{"Category"}</div>
          <p className="text-gray-700 text-base">R$200,30</p>
        </div>
        <div className="px-6 pt-4 pb-2">
          <button className="bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded">
            Add to Cart
          </button>
        </div>
      </div>
    </>
  );
}
