//DANIEL GIELOW JUNIOR

package AlgoritmoBuscaTest;

import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.junit.runners.JUnit4;

import Questao6.AlgoritmosDeBusca;
import Questao6.Grafo;
import Questao6.Vertice;
import Questao6.VetorRoteamento;

@RunWith(JUnit4.class)
public class BuscaEmLarguraTeste {
	private AlgoritmosDeBusca buscaEmLargura;
	@Before
	public void setup()
	{
		buscaEmLargura = new AlgoritmosDeBusca();
	}
	
	
	@Test
	public void realizarBuscaLargura(){
		//BFS
		Grafo grafo = new Grafo();
		Vertice vR = new Vertice("R");
		Vertice vS = new Vertice("S");
		Vertice vT = new Vertice("T");
		Vertice vU = new Vertice("U");
		Vertice vV = new Vertice("V");
		Vertice vW = new Vertice("W");
		Vertice vX = new Vertice("X");
		Vertice vY = new Vertice("Y");

		vR.setAdjacencias(vS, vV);
		vS.setAdjacencias(vR, vW);
		vT.setAdjacencias(vW, vU, vX);
		vU.setAdjacencias(vT, vX, vY);
		vV.setAdjacencias(vR);
		vW.setAdjacencias(vS, vT, vX);
		vX.setAdjacencias(vW, vT, vU, vY);
		vY.setAdjacencias(vY, vU);
		
		grafo.adicionarVertices(vR, vS, vT, vU, vV, vW, vX, vY);
		
		VetorRoteamento retorno = buscaEmLargura.buscarEmLargura(grafo, vR);
		
		System.out.println("Vetor de roteamento:");
		System.out.println(retorno);
	}
}
