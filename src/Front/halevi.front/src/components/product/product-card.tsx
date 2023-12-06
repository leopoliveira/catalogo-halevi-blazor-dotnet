export default function ProductCard() {
  return (
    <>
      <div className="flex flex-col bg-white shadow-lg rounded-lg p-6 m-4">
        <div
          className="w-1/2 h-32 bg-cover bg-center mb-4 mx-auto"
          style={{
            backgroundImage: "url('https://via.placeholder.com/75')",
          }}></div>
        <div
          id="body"
          className="flex flex-col h-32 justify-between">
          <div className="font-bold text-xl mb-2">Product 1</div>
          <div className="text-gray-700 mb-2">Category</div>
          <div className="text-gray-900 font-bold text-lg mb-2">
            R$ 200,00
          </div>
        </div>
        <div
          id="footer"
          className="flex items-center justify-center">
          <div className="w-1/2 bg-green-700 text-white text-center py-2 rounded hover:bg-green-500 hover:text-black hover:font-bold transition-colors duration-300 cursor-pointer">
            Add to Cart
          </div>
        </div>
      </div>
    </>
  );
}
