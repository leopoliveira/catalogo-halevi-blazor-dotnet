import Footer from "@/components/layout/footer";
import Header from "@/components/layout/header";
import Navbar from "@/components/layout/navbar";
import Main from "@/components/layout/main";

export default function Page() {
  return (
    <>
      <Header />
      <div className="flex flex-col mt-4">
        <div className="flex flex-col">
          <Navbar />
          <Main />
        </div>
        <Footer />
      </div>
    </>
  );
}
