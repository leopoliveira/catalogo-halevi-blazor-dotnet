/** @type {import('next').NextConfig} */
const nextConfig = {
  images: {
    remotePatterns: [
      {
        protocol: "https",
        hostname: "cdn.architect.io",
      },
    ],
    domains: ["localhost", "via.placeholder.com"],
  },
};

module.exports = nextConfig;
