package test;

import java.util.List;

import org.junit.Assert;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.junit.runners.JUnit4;

import Algoritmo.NoArvore;

@RunWith(JUnit4.class)
public class NoArvoreTeste {
	
	@Test
	public void toStringDeUmNoFolha(){
		NoArvore no = new NoArvore("A", 1);
		Assert.assertEquals(no.toString(), "<A<><>>");
	}
	
	@Test
	public void toStringDeUmNoComNoFilhoAEsquerda(){
		NoArvore no = new NoArvore("A", 1);
		no.setNoEsquerdo(new NoArvore("B", 1));
		Assert.assertEquals(no.toString(), "<A<B<><>><>>");
	}
	
	@Test
	public void toStringDeUmNoComFilhoADireita(){
		NoArvore no = new NoArvore("A", 1);
		no.setNoDireito(new NoArvore("B", 1));
		Assert.assertEquals(no.toString(), "<A<><B<><>>>");
	}
	
	@Test
	public void toStringDeUmNoComSeusDoisFilhos(){
		NoArvore no = new NoArvore("A", 1);
		no.setNoEsquerdo(new NoArvore("B", 1));
		no.setNoDireito(new NoArvore("C", 1));
		Assert.assertEquals(no.toString(), "<A<B<><>><C<><>>>");
	}
	
	@Test
	public void caminhoDeUmNo(){
		NoArvore noEsquerda = new NoArvore("A", 1);
		NoArvore noDireita = new NoArvore("B", 3);
		NoArvore noPrincipal = new NoArvore(noEsquerda, noDireita);
		
		Assert.assertEquals(noPrincipal.getCaminho(), "");
		Assert.assertEquals(noEsquerda.getCaminho(), "0");
		Assert.assertEquals(noDireita.getCaminho(), "1");
	}
	
	@Test
	public void caminhoDeUmNoEmDoisNiveis(){
		NoArvore noEsquerda1 = new NoArvore("A", 1);
		NoArvore noEsquerda2 = new NoArvore("B", 2);
		NoArvore noDireita1 = new NoArvore("A", 1);
		NoArvore noDireita2 = new NoArvore("B", 2);
		
		NoArvore noEsquerda = new NoArvore(noEsquerda1, noEsquerda2);
		NoArvore noDireita = new NoArvore(noDireita1, noDireita2);
		NoArvore noPrincipal = new NoArvore(noEsquerda, noDireita);
		
		Assert.assertEquals(noPrincipal.getCaminho(), "");
		Assert.assertEquals(noEsquerda.getCaminho(), "0");
		Assert.assertEquals(noDireita.getCaminho(), "1");
		Assert.assertEquals(noEsquerda1.getCaminho(), "00");
		Assert.assertEquals(noEsquerda2.getCaminho(), "01");
		Assert.assertEquals(noDireita1.getCaminho(), "10");
		Assert.assertEquals(noDireita2.getCaminho(), "11");		
	}
	
	@Test
	public void buscandoNosFolhasEmUmNoFolha(){
		NoArvore noFolha = new NoArvore("A", 1);
		
		List<NoArvore> nosFolhas = noFolha.obterNosFolhas();
		Assert.assertEquals(nosFolhas.size(), 1);
		Assert.assertEquals(nosFolhas.get(0), noFolha);
	}
	
	@Test
	public void buscandoNosFolhaDeUmNo(){
		NoArvore noEsquerda = new NoArvore("A", 1);
		NoArvore noDireita = new NoArvore("B", 2);
		NoArvore noPrincipal = new NoArvore(noEsquerda, noDireita);
		
		List<NoArvore> nosFolhas = noPrincipal.obterNosFolhas();
		Assert.assertEquals(nosFolhas.size(), 2);
		Assert.assertEquals(nosFolhas.get(0), noEsquerda);
		Assert.assertEquals(nosFolhas.get(1), noDireita);
	}
	
	@Test 
	public void buscandoNosFolhaEmDoisNiveis(){
		NoArvore noEsquerda1 = new NoArvore("A", 1);
		NoArvore noEsquerda2 = new NoArvore("B", 2);
		NoArvore noDireita1 = new NoArvore("A", 1);
		NoArvore noDireita2 = new NoArvore("B", 2);
		
		NoArvore noEsquerda = new NoArvore(noEsquerda1, noEsquerda2);
		NoArvore noDireita = new NoArvore(noDireita1, noDireita2);
		NoArvore noPrincipal = new NoArvore(noEsquerda, noDireita);
		
		List<NoArvore> nosFolhas = noPrincipal.obterNosFolhas();
		Assert.assertEquals(nosFolhas.size(), 4);
		Assert.assertEquals(nosFolhas.get(0), noEsquerda1);
		Assert.assertEquals(nosFolhas.get(1), noEsquerda2);
		Assert.assertEquals(nosFolhas.get(2), noDireita1);
		Assert.assertEquals(nosFolhas.get(3), noDireita2);
	}
}
