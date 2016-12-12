import org.junit.Before;
import org.junit.Test;

import static org.junit.Assert.assertEquals;

public class MyFirstTest {
    @Before
    public void setup()
    {
    }

    @Test
    public void shouldWork() {
        assertEquals(1+1, 2);
    }

}
