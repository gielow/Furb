(load "util.lisp")
(defun imc (peso altura) (/ peso (potencia altura 2)))
(setq altura 1.80)
(setq peso 80)
(print (imc peso altura))
(read-line)