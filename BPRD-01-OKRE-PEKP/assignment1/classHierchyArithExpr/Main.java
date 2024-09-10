import java.util.*;

abstract class Expr {
    public abstract String toString();

    /*
     * Exercise 1.4 (iii) Extend your classes with facilities to evaluate the
     * arithmetic expressions, that is,addamethodint eval(env).
     */

    public abstract int eval(Map<String, Integer> env);

    /*
     * Exercise 1.4 (iv) Ad a method Expr simplify() that returns a new expression
     * where algebraic simplifications have been performed.
     */

    public abstract Expr simplify();
}

class CstI extends Expr {
    protected final int i;

    public CstI(int i) {
        this.i = i;
    }

    @Override
    public String toString() {
        return Integer.toString(i);
    }

    /*
     * Exercise 1.4 (iii) Extend your classes with facilities to evaluate the
     * arithmetic expressions, that is,addamethodint eval(env).
     */

    @Override
    public int eval(Map<String, Integer> env) {
        return i;
    }

    /*
     * Exercise 1.4 (iv) Ad a method Expr simplify() that returns a new expression
     * where algebraic simplifications have been performed.
     */

    @Override
    public Expr simplify() {
        return this;
    }
}

class Var extends Expr {
    protected final String n;

    public Var(String n) {
        this.n = n;
    }

    @Override
    public String toString() {
        return n;
    }

    /*
     * Exercise 1.4 (iii) Extend your classes with facilities to evaluate the
     * arithmetic expressions, that is,addamethodint eval(env).
     */

    @Override
    public int eval(Map<String, Integer> env) {
        return env.get(n);
    }

    /*
     * Exercise 1.4 (iv) Ad a method Expr simplify() that returns a new expression
     * where algebraic simplifications have been performed.
     */

    @Override
    public Expr simplify() {
        return this;
    }
}

abstract class Binop extends Expr {
    protected Expr right;
    protected Expr left;

    public Binop(Expr left, Expr right) {
        this.left = left;
        this.right = right;
    }
}

class Add extends Binop {
    public Add(Expr left, Expr right) {
        super(left, right);
    }

    @Override
    public String toString() {
        return "(" + left + " + " + right + ")";
    }

    /*
     * Exercise 1.4 (iii) Extend your classes with facilities to evaluate the
     * arithmetic expressions, that is,addamethodint eval(env).
     */

    @Override
    public int eval(Map<String, Integer> env) {
        return left.eval(env) + right.eval(env);
    }

    /*
     * Exercise 1.4 (iv) Ad a method Expr simplify() that returns a new expression
     * where algebraic simplifications have been performed.
     */

    @Override
    public Expr simplify() {
        Expr simpleLeft = left.simplify();
        Expr simpleRight = right.simplify();

        // Simplify cases like x + 0 or 0 + x
        if (simpleLeft instanceof CstI && ((CstI) simpleLeft).eval(null) == 0) {
            return simpleRight;
        }
        if (simpleRight instanceof CstI && ((CstI) simpleRight).eval(null) == 0) {
            return simpleLeft;
        }

        // Constant folding
        if (simpleLeft instanceof CstI && simpleRight instanceof CstI) {
            return new CstI(((CstI) simpleLeft).eval(null) + ((CstI) simpleRight).eval(null));
        }

        return new Add(simpleLeft, simpleRight);
    }
}

class Mul extends Binop {
    public Mul(Expr left, Expr right) {
        super(left, right);
    }

    @Override
    public String toString() {
        return "(" + left + " * " + right + ")";
    }

    /*
     * Exercise 1.4 (iii) Extend your classes with facilities to evaluate the
     * arithmetic expressions, that is,addamethodint eval(env).
     */

    @Override
    public int eval(Map<String, Integer> env) {
        return left.eval(env) * right.eval(env);
    }

    /*
     * Exercise 1.4 (iv) Ad a method Expr simplify() that returns a new expression
     * where algebraic simplifications have been performed.
     */

    @Override
    public Expr simplify() {
        Expr simpleLeft = left.simplify();
        Expr simpleRight = right.simplify();

        // Simplify cases like x * 1 or 1 * x
        if (simpleLeft instanceof CstI && ((CstI) simpleLeft).eval(null) == 1) {
            return simpleRight;
        }
        if (simpleRight instanceof CstI && ((CstI) simpleRight).eval(null) == 1) {
            return simpleLeft;
        }

        // Simplify cases like x * 0 or 0 * x
        if (simpleLeft instanceof CstI && ((CstI) simpleLeft).eval(null) == 0) {
            return new CstI(0);
        }
        if (simpleRight instanceof CstI && ((CstI) simpleRight).eval(null) == 0) {
            return new CstI(0);
        }

        // Constant folding
        if (simpleLeft instanceof CstI && simpleRight instanceof CstI) {
            return new CstI(((CstI) simpleLeft).eval(null) * ((CstI) simpleRight).eval(null));
        }

        return new Mul(simpleLeft, simpleRight);
    }
}

class Sub extends Binop {
    public Sub(Expr left, Expr right) {
        super(left, right);
    }

    @Override
    public String toString() {
        return "(" + left + " - " + right + ")";
    }

    /*
     * Exercise 1.4 (iii) Extend your classes with facilities to evaluate the
     * arithmetic expressions, that is,addamethodint eval(env).
     */

    @Override
    public int eval(Map<String, Integer> env) {
        return left.eval(env) - right.eval(env);
    }

    /*
     * Exercise 1.4 (iv) Ad a method Expr simplify() that returns a new expression
     * where algebraic simplifications have been performed.
     */

    @Override
    public Expr simplify() {
        Expr simpleLeft = left.simplify();
        Expr simpleRight = right.simplify();

        // Simplify cases like x - 0
        if (simpleRight instanceof CstI && ((CstI) simpleRight).eval(null) == 0) {
            return simpleLeft;
        }

        // Constant folding
        if (simpleLeft instanceof CstI && simpleRight instanceof CstI) {
            return new CstI(((CstI) simpleLeft).eval(null) - ((CstI) simpleRight).eval(null));
        }

        return new Sub(simpleLeft, simpleRight);
    }
}

public class Main {
    public static void main(String[] args) {
        /*
         * Exercise 1.4 (ii) Create three more expressions in abstract syntax and print
         * them.
         */
        Expr e = new Add(new CstI(17), new Var("z"));
        Expr e1 = new Sub(new Var("v"), new Add(new Var("w"), new Var("z")));
        Expr e2 = new Mul(new CstI(2), e1);
        Expr e3 = new Add(new Add(new Var("x"), new Var("y")), new Add(new Var("z"), new Var("v")));

        System.out.println(e.toString()); // (17 + z)
        System.out.println(e1.toString()); // (v - (w + z))
        System.out.println(e2.toString()); // (2 * (v - (w + z)))
        System.out.println(e3.toString()); // ((x + y) + z) + v))
    }
}