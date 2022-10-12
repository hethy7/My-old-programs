package TextSztego;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.LineNumberReader;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Scanner;

public class Encrypt {

	private static Scanner be;

	public static void main(String[] args) throws IOException {

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

		System.out.println("Szöveg alapú szteganográfia - Kódolás");
		System.out.println();

		// INFORMACIOK
		File f1 = new File("hordozo.txt");
		LineNumberReader lnr = new LineNumberReader(new FileReader(f1));
		lnr.skip(Long.MAX_VALUE);
		int horsor = lnr.getLineNumber() + 1; // hordozo sorainak szama
		System.out.println("A hordozónak összesen " + horsor + " sora van.");
		lnr.close();

		System.out.println("Egy sorban hány bitet kódoljunk? (4 vagy 8)");
		be = new Scanner(System.in);
		byte hbit = be.nextByte(); // mennyi bitcsoport

		while (!(hbit == 4 || hbit == 8)) {
			System.out
					.println("Rossz értéket adtál meg, adj meg egy másikat: ");
			hbit = be.nextByte();
		}

		double uzenetmh = hbit * (horsor - 4) / 8; // uzenet max hossz
		// (3 sort felre teszunk az informacionak)
		if (uzenetmh < 1024) {
			System.out.println("Összesen " + uzenetmh
					+ " bájtnyi adatot tudunk elrejteni.");
		} else if (uzenetmh < 1024 * 1024) {
			System.out.println("Összesen "
					+ String.format("%.2f", (uzenetmh / 1024))
					+ " Kb adatot tudunk elrejteni.");
		} else {
			System.out.println("Összesen "
					+ String.format("%.2f", (uzenetmh / (1024 * 1024)))
					+ " Mb adatot tudunk elrejteni.");
		}

		System.out.println("Add meg az elrejtendõ fájl nevét: ");
		String unev = be.next(); // fájl neve

		String fk = ""; // milyen fajlkiterjesztes
		char ch;

		for (int i = 0; i < unev.length(); i++) {
			ch = unev.charAt(i);
			fk += ch;
			if (ch == '.')
				fk = "";
		}

		int fkod = -1; // a fajl kodja

		for (int i = 0; i < fajlk.length; i++) {
			if (fk.equals(fajlk[i])) {
				fkod = i;
				break;
			}
		}

		if (fkod < 0) {
			System.out.println("Ilyen típusú fájlt nem tudunk elrejteni!");
			System.out.println("Nem sikerült elrejtenünk az üzenetet!");
		} else {

			File f2 = new File(unev);
			if (uzenetmh < f2.length()) {
				System.out.println("Túl nagy az elrejtendõ fájl mérete!");
				System.out.println("Nem sikerült elrejtenünk az üzenetet!");
			} else {
				System.out.println("Megfelelõ méretû az elrejtendõ fájl.");

				// KODOLAS
				Path path = Paths.get(unev);
				byte[] ubajts = Files.readAllBytes(path); // az uzenet
															// bajtonkkent
				String szoveg;

				File f3 = new File("sztegotext.txt");
				try (BufferedReader br = new BufferedReader(new FileReader(f1));
						BufferedWriter bw = new BufferedWriter(new FileWriter(
								f3))) {

					// az 1. sorba kimentjuk, hogy milyen bitcsoportok lesznek:
					// 4(1 space) vagy 8(2 space)
					szoveg = br.readLine();
					szoveg = szoveg.trim();
					for (int i = 0; i < (hbit / 4); i++) {
						szoveg += " ";
					}
					bw.write(szoveg);
					bw.newLine();

					// a 2.sorba a fajl tipusat
					szoveg = br.readLine();
					szoveg = szoveg.trim();
					for (int i = 0; i < fkod / 16; i++) {
						szoveg += " ";
					}
					bw.write(szoveg);
					bw.newLine();

					// a 3.sorba is a fajl tipusat
					szoveg = br.readLine();
					szoveg = szoveg.trim();
					for (int i = 0; i < fkod % 16; i++) {
						szoveg += " ";
					}
					bw.write(szoveg);
					bw.newLine();

					// a tobbi sorba az uzenet bitjeit (4-es vagy 8-as
					// csoportokban)
					int pbajt;
					if (hbit == 8) {
						for (int i = 0; i < ubajts.length; i++) {
							pbajt = ubajts[i] & 0xFF;
							szoveg = br.readLine();
							szoveg = szoveg.trim();
							for (int j = 0; j < pbajt; j++)
								szoveg += " ";
							bw.write(szoveg);
							bw.newLine();
						}
					} else {
						int fel1, fel2;
						for (int i = 0; i < ubajts.length; i++) {
							pbajt = ubajts[i] & 0xFF;
							fel1 = pbajt / 16; // a bajt 1. fele
							fel2 = pbajt % 16; // a bajt 2. fele
							szoveg = br.readLine();
							szoveg = szoveg.trim();
							for (int j = 0; j < fel1; j++)
								szoveg += " ";
							bw.write(szoveg);
							bw.newLine();
							szoveg = br.readLine();
							szoveg = szoveg.trim();
							for (int j = 0; j < fel2; j++)
								szoveg += " ";
							bw.write(szoveg);
							bw.newLine();
						}
					}
					
					// a kodolas veget megjegyzem tab-al
					szoveg = br.readLine();
					szoveg = szoveg.trim();					
					bw.write(szoveg+"\t");
					bw.newLine();

					// maradek sor kiirasa(kodolas nelkul)
					while ((szoveg = br.readLine()) != null) {
						szoveg = szoveg.trim();
						bw.write(szoveg);
						bw.newLine();
					}

					System.out.println("Az üzenetet sikeresen elrejtettük.");

				} catch (FileNotFoundException e) {
					System.out.println("Hiba a fajl megnyitaskor"
							+ e.getMessage());
				} catch (IOException e) {
					System.out.println("Fajl olvasasi/irási hiba:"
							+ e.getMessage());
				}
			}
		}
	}
}
