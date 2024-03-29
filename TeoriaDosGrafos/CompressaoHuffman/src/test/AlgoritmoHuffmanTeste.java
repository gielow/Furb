package test;


import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.Scanner;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.junit.runners.JUnit4;

import Algoritmo.AlgoritmoHuffman;
import Algoritmo.Arvore;
import Algoritmo.NoArvore;

@RunWith(JUnit4.class)
public class AlgoritmoHuffmanTeste {
	
	private AlgoritmoHuffman algoritmoHuffman;

	@Before
	public void SetUp(){
		algoritmoHuffman = new AlgoritmoHuffman();
	}
	
	@Test
	public void buscarArvoreDeCompactacaoParaUmDeterminadoTexto(){
		String texto = "AABBAACCAABBAAAAABBBC";
		Arvore arvore = algoritmoHuffman.montarArvoreDeCompactacao(texto);
		
		Assert.assertNotNull(arvore);
		Assert.assertEquals(arvore.getNoPrincipal().getPeso(), 21);		
	}
	
	@Test
	public void transformarArvoreEmUmDicionarioDeHuffman(){
		NoArvore noFolhaEsquerda1 = new NoArvore("A", 5);
		NoArvore noFolhaEsquerda2 = new NoArvore("B", 7);
		NoArvore noEsquerda = new NoArvore(noFolhaEsquerda1, noFolhaEsquerda2);
		
		NoArvore noFolhaDireita1 = new NoArvore("C", 6);
		NoArvore noFolhaDireita2 = new NoArvore("D", 8);
		NoArvore noDireita = new NoArvore(noFolhaDireita1, noFolhaDireita2);
		
		NoArvore noPrincipal = new NoArvore(noEsquerda, noDireita);
		Arvore arvore = new Arvore(noPrincipal);
		
		Map<String, String> dicionario = algoritmoHuffman.ObterDicionario(arvore);

		Assert.assertEquals(dicionario.size(), 4);
		Assert.assertEquals(dicionario.get("A"), "00");
		Assert.assertEquals(dicionario.get("B"), "01");
		Assert.assertEquals(dicionario.get("C"), "10");
		Assert.assertEquals(dicionario.get("D"), "11");
	}
	
	@Test
	public void compactarUmTextoUsandoUsandoUmaArvoreDeCompactacao(){
		String texto = "AABBCABC";
		NoArvore noEsquerda1 = new NoArvore("A", 3);
		NoArvore noEsquerda2 = new NoArvore("B", 3);
		
		NoArvore noEsquerda = new NoArvore(noEsquerda1, noEsquerda2);
		NoArvore noDireita = new NoArvore("C", 2);
		
		NoArvore noPrincipal = new NoArvore(noEsquerda, noDireita);
		Arvore arvore = new Arvore(noPrincipal);
		
		String resultado = algoritmoHuffman.CompactarInformandoUmaArvore(texto, arvore);
		Assert.assertEquals("<ABC<AB<A<><>><B<><>>><C<><>>>00000101100011", resultado);
	}
	
	@Test
	public void compactarUmTextoQualquer(){
		String resultado = algoritmoHuffman.CompactarTexto("AABABCA");
		Assert.assertEquals("<CBA<CB<C<><>><B<><>>><A<><>>>1101101001", resultado);
	}
	
	@Test
	public void compactarUmArquivoQualquer() throws FileNotFoundException{
		List<String> arquivos = new ArrayList<String>();
		arquivos.add("C:\\dev\\Furb\\TeoriaDosGrafos\\CompressaoHuffman\\src\\test\\ArquivosTeste\\49.in");
		arquivos.add("C:\\dev\\Furb\\TeoriaDosGrafos\\CompressaoHuffman\\src\\test\\ArquivosTeste\\49.in");
		arquivos.add("C:\\dev\\Furb\\TeoriaDosGrafos\\CompressaoHuffman\\src\\test\\ArquivosTeste\\499.in");
		arquivos.add("C:\\dev\\Furb\\TeoriaDosGrafos\\CompressaoHuffman\\src\\test\\ArquivosTeste\\4999.in");
		arquivos.add("C:\\dev\\Furb\\TeoriaDosGrafos\\CompressaoHuffman\\src\\test\\ArquivosTeste\\9999.in");
		arquivos.add("C:\\dev\\Furb\\TeoriaDosGrafos\\CompressaoHuffman\\src\\test\\ArquivosTeste\\17499.in");
		arquivos.add("C:\\dev\\Furb\\TeoriaDosGrafos\\CompressaoHuffman\\src\\test\\ArquivosTeste\\49999.in");
		
		for(String arquivo : arquivos){
			String conteudoNaoCompactado = new Scanner(new File(arquivo)).useDelimiter("\\A").next();
			String conteudoCompactado = algoritmoHuffman.CompactarArquivo(arquivo);
			int index = conteudoCompactado.lastIndexOf(">");
			String arvoreCompactacap = conteudoCompactado.substring(0, index + 1);
			String bytesCompactados = conteudoCompactado.substring(index + 1);
			
			System.out.println("Arquivo: " + arquivo);
			System.out.println("Bytes n�o compactados: " + (conteudoNaoCompactado.length() * 8));
			System.out.println("Bytes compactados: " + (arvoreCompactacap.length() * 8 + bytesCompactados.length()));
		}
		
	}
}
