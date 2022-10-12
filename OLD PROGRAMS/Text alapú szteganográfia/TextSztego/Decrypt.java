package TextSztego;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.IOException;

public class Decrypt {

	public static void main(String[] args) {

		String[] fajlk = { "bin", "drv", "inf", "ini", "log", "mnu", "msg",
				"pif", "pro", "sys", "bak", "bkf", "gho", "qic", "tmp", "$$$",
				"com", "bat", "exe", "lnk", "scr", "asm", "bas", "c", "cs",
				"cpp", "dpr", "java", "ly", "pas", "pl", "pm", "pp", "php",
				"py", "rb", "js", "lib", "map", "obj", "dat", "txt", "wri",
				"lpr", "kst", "doc", "docx", "rtf", "pdf", "htm", "html", "ps",
				"lit", "chm", "hlp", "odt", "diz", "bmp", "tif", "gif", "png",
				"jpeg", "jpg", "tga", "cps", "wmf", "eps", "emf", "cdr", "swf",
				"svg", "avi", "mov", "wmv", "3gp", "mp4", "mpeg", "mpg",
				"divx", "xvid", "mkv", "wav", "au", "mid", "mp3", "wma", "ogg",
				"flac", "7z", "aac", "ace", "arc", "arj", "bz2", "gz", "lha",
				"jar", "rar", "tar", "z", "zip", "xls", "xlsx", "xlc", "wq1",
				"wks", "odf", "mdb", "dbf", "dbt", "nxd", "mem", "qry", "cat",
				"vue", "fmt", "fmr", "lbl", "prg", "ntx", "ppt", "pptx", "pps",
				"pot", "qxd", "ind", "pmd", "pm65", "sla", "tex", "cdr", "fh8",
				"fh9", "fh10", "ai", "asv", "cde", "cdl", "fnt", "prt", "ptn",
				"mar", "nam", "tdf", "tle", "3ds", "ng", "ncd", "wc" };

		System.out.println("Szöveg alapú szteganográfia - Dekódolás");
		System.out.println();

		String szoveg;
		short mi = -1; // mi van elkodolva
		byte hbit = 0, szam, szam2; // hbit - hany bitenkent
		// mennyi bitcsoportonkent
		File f1 = new File("sztegotext.txt");

		// INFO dekodolas
		try (BufferedReader br = new BufferedReader(new FileReader(f1))) {

			// bitcsoport
			szoveg = br.readLine();
			szam = 0;

			for (int i = szoveg.length() - 1; i >= 0; i--) {
				if (szoveg.charAt(i) == ' ')
					szam++;
				else
					break;
			}
			hbit = szam;

			// milyen fajlkiterjesztes
			szoveg = br.readLine();
			szam = 0;
			for (int i = szoveg.length() - 1; i >= 0; i--) {
				if (szoveg.charAt(i) == ' ')
					szam++;
				else
					break;
			}

			szoveg = br.readLine();
			szam2 = 0;
			for (int i = szoveg.length() - 1; i >= 0; i--) {
				if (szoveg.charAt(i) == ' ')
					szam2++;
				else
					break;
			}

			mi = (short) (szam * 16 + szam2);

		} catch (FileNotFoundException e) {
			System.out.println("Hiba a fajl megnyitaskor" + e.getMessage());
		} catch (IOException e) {
			System.out.println("Fajl olvasasi hiba:" + e.getMessage());
		}

		if (mi < 0) {
			System.out.println("HIBA!!!");
			System.out.println("A dekódolás sikertelen!");
		} else {
			String unev = "kuldottuzenet." + fajlk[mi];
			System.out
					.println("A sztegotextbe egy " + fajlk[mi]
							+ " fajl van elkódolva, soronként " + hbit * 4
							+ " bittel.");
			System.out.println("Az üzenet a " + unev + "-be található.");

			// UZENET dekodolas
			File f2 = new File(unev);
			try (BufferedReader br = new BufferedReader(new FileReader(f1));
					FileOutputStream fos = new FileOutputStream(f2)) {

				br.readLine(); // a hbit es
				br.readLine(); // ...
				br.readLine(); // a mi mar nem kellenek!
				szoveg = br.readLine();

				// tabulatorig olvassa be az uzenetet
				while (szoveg.charAt(szoveg.length() - 1) != '\t') {

					szam = 0;
					for (int i = szoveg.length() - 1; i >= 0; i--) {
						if (szoveg.charAt(i) == ' ')
							szam++;
						else
							break;
					}

					if (hbit * 4 == 8) {
						fos.write(szam);
					} else {
						szoveg = br.readLine();
						szam2 = 0;
						for (int i = szoveg.length() - 1; i >= 0; i--) {
							if (szoveg.charAt(i) == ' ')
								szam2++;
							else
								break;
						}
						szam = (byte) (szam * 16 + szam2);
						fos.write(szam);
					}

					szoveg = br.readLine();
				}
				fos.close();

			} catch (FileNotFoundException e) {
				System.out.println("Hiba a fajl megnyitaskor" + e.getMessage());
			} catch (IOException e) {
				System.out
						.println("Fajl olvasasi/irási hiba:" + e.getMessage());
			}
			System.out.println("A dekódolás sikeres volt.");
		}

	}

}
