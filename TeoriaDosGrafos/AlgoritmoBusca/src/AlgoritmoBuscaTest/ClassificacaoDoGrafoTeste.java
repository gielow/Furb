package AlgoritmoBuscaTest;


import junit.framework.Assert;

import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.junit.runners.JUnit4;

import Questao5.ClassificacaoDoGrafo;

@RunWith(JUnit4.class)
public class ClassificacaoDoGrafoTeste {
	
	private ClassificacaoDoGrafo classificacaoDoGrafo;
	@Before
	public void setup()
	{
		classificacaoDoGrafo = new ClassificacaoDoGrafo();
	}
	
	
	@Test
	public void verificarClassificacaoGrafoNulo(){
		int[][] matriz = {
				{0,0,0,0,0},
				{0,0,0,0,0},
				{0,0,0,0,0},
				{0,0,0,0,0},
				{0,0,0,0,0},				
		};
		
		String tipo = classificacaoDoGrafo.tipoDoGrafo(matriz);
		Assert.assertEquals(tipo, "nulo");
	}
	
	@Test
	public void verificarClassificacaoGrafoCompleto(){
		int[][] matriz1 = {
				{0,1,1,1},
				{1,0,1,1},
				{1,1,0,1},
				{1,1,1,0},				
		};
		
		Assert.assertEquals(classificacaoDoGrafo.tipoDoGrafo(matriz1), "completo");
		
		int[][] matriz2 = {
				{0},
		};
		
		Assert.assertEquals(classificacaoDoGrafo.tipoDoGrafo(matriz2), "completo");
	}
	
	@Test
	public void verificarClassificacaoGrafoRegular(){
		int[][] matriz1 = {
				{0,0,1,1},
				{0,0,1,1},
				{1,1,0,0},
				{1,1,0,0},				
		};
		Assert.assertEquals(classificacaoDoGrafo.tipoDoGrafo(matriz1), "regular");
	}
	
	@Test
	public void verificarClassificacaoGrafoBipartido(){
		int[][] matriz1 = {
				{0,0,1,1},
				{0,0,1,0},
				{0,1,0,0},
				{1,1,0,0},				
		};
		Assert.assertEquals(classificacaoDoGrafo.tipoDoGrafo(matriz1), "bipartido");
	}
	
	
	@Test
	public void verificarQuantidadeDeArestasDoGrafo(){
		int[][] matriz1 = {
				{0,0,1,1},
				{0,0,1,1},
				{1,1,0,0},
				{1,1,0,0},				
		};
		
		Assert.assertEquals(classificacaoDoGrafo.arestasDoGrafo(matriz1), "4 - E = {(1,3),(1,4),(2,3),(2,4)}");
	}
	
	@Test
	public void verificarGrauDeVerticesDoGrafo(){
		int[][] matriz1 = {
				{0,0,0,1},
				{0,0,1,1},
				{1,0,1,1},
				{1,1,1,0},				
		};
		
		Assert.assertEquals(classificacaoDoGrafo.grausDoVertice(matriz1), "g1=1,g2=2,g3=3,g4=3 - 1 2 3 3");
	}
}
	