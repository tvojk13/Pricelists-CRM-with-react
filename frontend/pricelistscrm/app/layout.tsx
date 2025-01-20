import "./globals.css";
import Layout, { Footer, Header } from "antd/es/layout/layout";
import { Menu } from "antd";
import Link from "next/link";
import Content from "antd/es/layout/";

const items = [
  {key: "home", label: <Link href={"/"}>Home</Link>},
  {key: "pricelists", label: <Link href={"/pricelists"}>Pricelists</Link>}
]

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body>
        <Layout style={{ minHeight: "100vh" }}>
          <Header>
            <Menu 
              theme="dark"
              mode="horizontal"
              items={items}
              style={{ flex: 1, minWidth: 0 }}
              />
          </Header>
          <Content style={{ padding: "0 48px"}}>{children}</Content>
          <Footer style= {{ textAlign: "center" }}>
            Pricelists CRM by tvojk13
          </Footer>
        </Layout>
      </body>
    </html>
  );
}
