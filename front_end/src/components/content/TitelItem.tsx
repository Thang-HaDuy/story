import Button from '@mui/material/Button';
import Box from '@mui/material/Box';
import React from 'react';
import ChevronRightIcon from '@mui/icons-material/ChevronRight';
import Link from 'next/link';

const TitelItem = ({
    children,
    title,
    childrenTitle,
}: {
    children: React.ReactNode;
    title: string;
    childrenTitle: React.ReactNode;
}) => {
    return (
        <Box>
            <Box
                sx={{
                    display: 'flex',
                    marginBottom: '20px',
                }}
            >
                <Button
                    endIcon={<ChevronRightIcon />}
                    sx={{
                        background: 'linear-gradient(81.43deg,#b71c1c -26.81%,#8e1438 87.89%)',
                        cursor: 'default',
                        padding: '8px',
                        fontSize: '18px',
                        fontWeight: '500',
                        lineHeight: '19.8px',
                        marginRight: '8px',
                    }}
                >
                    {title}
                </Button>
                {childrenTitle}
            </Box>
            {children}
            <Box
                component={Link}
                href={'/'}
                sx={{
                    width: '100%',
                    backgroundColor: '#161e21',
                    display: 'flex',
                    justifyContent: 'center',
                    textDecoration: 'none',
                    color: '#fff',
                    padding: '5px',
                    marginBottom: '20px',
                    fontSize: '18px',
                    fontWeight: '300',
                    lineHeight: '27px',
                    '&:hover': { color: '#7d7d7d' },
                }}
            >
                XEM THÊM...
            </Box>
        </Box>
    );
};

export default TitelItem;
